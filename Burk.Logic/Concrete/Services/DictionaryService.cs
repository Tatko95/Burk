using Burk.Core.Service;
using Burk.Logic.Abstract.Services;
using Burk.Model.UDB;
using System;
using System.Linq;
using Burk.Core.Repository;
using Burk.Logic.Abstract.Repositories;

namespace Burk.Logic.Concrete.Services
{
    public class DictionaryService : BaseService<Dictionary>, IDictionaryService
    {
        #region CTOR
        public DictionaryService(IBurkModelRepository repo) : base(repo) { }
        #endregion

        #region Dictonary
        public IQueryable<Dictionary> GetDictionaries(int systemId)
        {
            var result = repository.Table<Dictionary>().Where(x => x.SystemId == systemId);
            return result;
        }
        #endregion

        #region Dictionary Value
        public IQueryable<DictionaryValue> GetDictionaryValues(int dictionaryId)
        {
            var result = repository.Table<DictionaryValue>().Where(x => x.DictionaryId == dictionaryId);
            return result;
        }

        #region CRUD
        public void DeleteValue(DictionaryValue model)
        {
            repository.Delete(model);
        }

        public DictionaryValue GetValueById(int id)
        {
            var model = repository.Table<DictionaryValue>().FirstOrDefault(x => x.DicValueId == id);
            return model?? new DictionaryValue();
        }

        public void InsertValue(DictionaryValue value)
        {
            repository.Insert(value);
        }

        public void UpdateValue(DictionaryValue value)
        {
            repository.Update(value);
        }
        #endregion
        #endregion
    }
}
