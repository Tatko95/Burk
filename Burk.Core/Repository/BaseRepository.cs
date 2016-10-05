﻿using Burk.Core.Abstract.Log;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Burk.Core.Repository
{
    public abstract class BaseRepository : IBaseRepository
    {
        #region Fields
        protected DbContext dbContext;
        private ILog logger;
        #endregion

        #region CTOR
        //public BaseRepository(ILog logger)
        //{
        //    this.logger = logger;
        //}
        #endregion


        #region Basic
        public void BeginTransaction()
        {
            if (dbContext.Database.Connection.State != ConnectionState.Open)
                dbContext.Database.Connection.Open();
            dbContext.Database.Connection.BeginTransaction();
        }

        public void SubmitChange()
        {
            dbContext.SaveChanges();
        }

        public void Rollback()
        {
            if (dbContext.Database.CurrentTransaction != null)
                try
                {
                    dbContext.Database.CurrentTransaction.Rollback();
                }
                catch
                {
                    ///
                    /// Тут надо разобраться, почему правильно не происходит откат транзакции
                    ///
                }
                finally
                {
                    if (dbContext.Database.Connection.State == ConnectionState.Open)
                        dbContext.Database.Connection.Close();
                }
        }

        public void Commit()
        {
            if (dbContext.Database.CurrentTransaction != null)
                try
                {
                    dbContext.Database.CurrentTransaction.Commit();
                }
                catch
                {
                    dbContext.Database.CurrentTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (dbContext.Database.Connection.State == ConnectionState.Open)
                        dbContext.Database.Connection.Close();
                }
        }
        #endregion

        #region CRUD
        public IQueryable<T> Table<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public T Insert<T>(T entity) where T : class
        {
            InsertOperation<T> operation = new InsertOperation<T>(this);
            operation.Execute(entity);
            return entity;
        }

        public void Update<T>(T entity) where T : class
        {
            UpdateOperation<T> operation = new UpdateOperation<T>(this);
            operation.Execute(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            DeleteOperation<T> operation = new DeleteOperation<T>(this);
            operation.Execute(entity);
        }
        #endregion

        #region Operation
        private abstract class BaseOperation<T> where T : class
        {
            protected BaseRepository repository;

            public BaseOperation(BaseRepository repository)
            {
                this.repository = repository;
            }

            public void Execute(T entity)
            {
                DbContext dbContext = repository.dbContext;
                //DbTransaction trans = dataContext.Database.;
                bool isTrans = dbContext.Database.CurrentTransaction != null ? true : false;
                try
                {
                    if (!isTrans)   // если открытой транзакции не было, то создаём новую
                    {
                        if (dbContext.Database.Connection.State != ConnectionState.Open)
                            dbContext.Database.Connection.Open();
                        dbContext.Database.Connection.BeginTransaction();
                    }

                    Operation(entity);
                    dbContext.SaveChanges();
                    if (!isTrans) repository.Commit(); // если открытой транзакции не было, то сохраняем изменения в базе
                }
                catch
                {
                    if (dbContext.Database.CurrentTransaction != null)
                        dbContext.Database.CurrentTransaction.Rollback();
                    throw;
                }
                finally
                {
                    if (!isTrans)
                        if (dbContext.Database.Connection.State == ConnectionState.Open)
                            dbContext.Database.Connection.Close();
                }
            }

            public abstract void Operation(T entity);
        }

        class InsertOperation<T> : BaseOperation<T> where T : class
        {
            public InsertOperation(BaseRepository repository)
                : base(repository)
            {
            }

            public override void Operation(T entity)
            {
                repository.dbContext.Set<T>().Add(entity);
            }
        }

        class UpdateOperation<T> : BaseOperation<T> where T : class
        {
            public UpdateOperation(BaseRepository repository)
                : base(repository)
            {
            }

            public override void Operation(T entity)
            {
                repository.dbContext.Set<T>().Attach(entity);
                repository.dbContext.Entry<T>(entity).State = EntityState.Modified;
            }
        }

        class DeleteOperation<T> : BaseOperation<T> where T : class
        {
            public DeleteOperation(BaseRepository repository)
                : base(repository)
            {
            }

            public override void Operation(T entity)
            {
                repository.dbContext.Set<T>().Remove(entity);
            }
        }
        #endregion
    }
}
