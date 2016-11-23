using System;
using System.Linq;

namespace Burk.Core.Service
{
    public interface IBaseService<T> where T : class
    {
        T GetById(string idName, string idValue);
        T Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        IQueryable<T> GetAll();
    }
}
