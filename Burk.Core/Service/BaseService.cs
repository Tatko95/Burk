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
        public virtual T GetById(string idName, string idValue)
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

        public virtual void Delete(T obj)
        {
            repository.Delete(obj);
        }

        public virtual T Insert(T obj)
        {
            return repository.Insert(obj);
        }

        public virtual void Update(T obj)
        {
            repository.Update(obj);
        }

        public virtual IQueryable<T> GetTable()
        {
            return repository.Table<T>();
        }
        #endregion
    }
}
