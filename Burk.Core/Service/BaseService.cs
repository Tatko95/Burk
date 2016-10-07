using Burk.Core.Repository;
using System;
using System.Linq;
using System.Linq.Dynamic;

namespace Burk.Core.Service
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        #region Fields
        protected IBaseRepository repository;
        #endregion

        #region CTOR
        public BaseService(IBaseRepository repo)
        {
            repository = repo;
        }
        #endregion

        #region Methods
        public T GetById(string idName, string idValue)
        {
            int idValueInt;
            object idValueObj;
            if (int.TryParse(idValue, out idValueInt))
                idValueObj = idValueInt;
            else
                idValueObj = idValue;

            T result = repository.Table<T>().Where(idName + " == @0", idValueObj).FirstOrDefault();
            return result;
        }

        public void Delete(T obj)
        {
            repository.Delete(obj);
        }

        public T Insert(T obj)
        {
            return repository.Insert(obj);
        }

        public void Update(T obj)
        {
            repository.Update(obj);
        }
        #endregion
    }

    public abstract class BaseService : IBaseService
    {
        #region Fields
        protected IBaseRepository repository;
        #endregion

        #region CTOR
        public BaseService(IBaseRepository repo)
        {
            repository = repo;
        }
        #endregion

        #region Methods
        public T GetById<T>(string idName, string idValue) where T : class
        {
            int idValueInt;
            object idValueObj;
            if (int.TryParse(idValue, out idValueInt))
                idValueObj = idValueInt;
            else
                idValueObj = idValue;

            T result = repository.Table<T>().Where(idName + " == @0", idValueObj).FirstOrDefault();
            return result;
        }

        public void Delete<T>(T obj) where T : class
        {
            repository.Delete<T>(obj);
        }

        public T Insert<T>(T obj) where T : class
        {
            return repository.Insert<T>(obj);
        }

        public void Update<T>(T obj) where T : class
        {
            repository.Update<T>(obj);
        }
        #endregion
    }
}
