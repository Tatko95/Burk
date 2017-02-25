using Burk.Core.Service;
using Burk.Model.UDB;
using System.Linq;

namespace Burk.Logic.Abstract.Services
{
    public interface IDictionaryService : IBaseService<Dictionary>
    {
        /// <summary>
        /// Список всіх довідників системи
        /// </summary>
        /// <param name="systemId">ІД системи</param>
        /// <returns>Список довідників</returns>
        IQueryable<Dictionary> GetDictionaries(int systemId);
        
        /// <summary>
        /// Список значень довідника
        /// </summary>
        /// <param name="dictionaryId">ІД довідника</param>
        /// <returns>Список значень</returns>
        IQueryable<DictionaryValue> GetDictionaryValues(int dictionaryId);

        /// <summary>
        /// Видалення значення довідника
        /// </summary>
        /// <param name="model">Обєкт</param>
        void DeleteValue(DictionaryValue model);

        /// <summary>
        /// Отримання значення довідника через ІД
        /// </summary>
        /// <param name="id">ІД значення</param>
        /// <returns>Значення довідника</returns>
        DictionaryValue GetValueById(int id);

        /// <summary>
        /// Вставка значення довідника
        /// </summary>
        /// <param name="value">Обєкт</param>
        void InsertValue(DictionaryValue value);

        /// <summary>
        /// Оновлення значення довідника
        /// </summary>
        /// <param name="value">Обєкт</param>
        void UpdateValue(DictionaryValue value);
    }
}
