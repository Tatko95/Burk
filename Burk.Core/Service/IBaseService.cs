using System;

namespace Burk.Core.Service
{
    public interface IBaseService<T> where T : class
    {
        T GetById(string idName, string idValue);
        T Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }

    public interface IBaseService
    {
        T GetById<T>(string idName, string idValue) where T : class;
        T Insert<T>(T obj) where T : class;
        void Update<T>(T obj) where T : class;
        void Delete<T>(T obj) where T : class;
    }
}
