using Burk.Core.Service;
using Burk.Model.UDB;
using System.Linq;

namespace Burk.Logic.Abstract.Services
{
    public interface IDictionaryService : IBaseService<Dictionary>
    {
        /// <summary>
        /// Отримання первого рівння атрибутів довідника
        /// </summary>
        /// <param name="dictionaryId">Ід довідника</param>
        /// <returns></returns>
        IQueryable<DictionaryAttribute> GetFirstLvl(int dictionaryId);
        /// <summary>
        /// Отримання наступного рівня атрибутів довідника
        /// </summary>
        /// <param name="dictionaryAttributeId">Ід атрибуту довідника</param>
        /// <returns></returns>
        IQueryable<DictionaryAttribute> GetNextLvl(int dictionaryAttributeId);
    }
}
