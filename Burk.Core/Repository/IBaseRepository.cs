using System.Collections.Generic;
using System.Linq;

namespace Burk.Core.Repository
{
    public interface IBaseRepository
    {
        IQueryable<T> Table<T>() where T : class;
        T Insert<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        void BeginTransaction();
        void Commit();
        void Rollback();
        void SubmitChange();

        //void Commit(int funcId, IDictionary<string, string> addParams);

        //IDictionary<string, string> GetCommitParams(params string[] keyThenValueArray);
    }
}
