using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burk.Logic.Repository
{
    public abstract class BaseRepository
    {
        #region Fields
        protected DbContext dbContext;
        protected string connectionString;
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
                //repository.dbContext.GetTable<K>().InsertOnSubmit(entity);
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
                
                // если объект не присоединём к dataContext, то присоединяем
                //repository.dbContext.Set<T>().
                //if (repository.dbContext.Set<T>().GetOriginalEntityState(entity) == null)
                //    repository.dataContext.GetTable<K>().Attach(entity);
                //repository.dataContext.Refresh(RefreshMode.KeepCurrentValues, entity);
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
