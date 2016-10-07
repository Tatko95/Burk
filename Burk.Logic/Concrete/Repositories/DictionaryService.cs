using Burk.Core.Service;
using Burk.Logic.Abstract.Services;
using Burk.Model.UDB;
using System;
using System.Linq;
using Burk.Core.Repository;

namespace Burk.Logic.Concrete.Repositories
{
    public class DictionaryService : BaseService<Dictionary>, IDictionaryService
    {
        #region CTOR
        public DictionaryService(IBaseRepository repo) : base(repo) { }
        #endregion

        #region Methods
        public IQueryable<DictionaryAttribute> GetFirstLvl(int dictionaryId)
        {
            var result = repository.Table<DictionaryAttribute>().Where(x => x.DictionaryId == dictionaryId);
            return result;
        }

        public IQueryable<DictionaryAttribute> GetNextLvl(int dictionaryAttributeId)
        {
            var result = repository.Table<DictionaryAttribute>().Where(x => x.DicAttributeLevelRefId == dictionaryAttributeId);
            return result;
        }
        #endregion
    }
}
