using Burk.Core.Service;
using Burk.Model.Misc;
using Burk.Model.UDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burk.Logic.Abstract.Services
{
    public interface IValueService : IBaseService<DossierValue>
    {
        /// <summary>
        /// Получение таблицы значений обэктов, по ид обэкта
        /// </summary>
        /// <param name="dossierId">ИД обэкта</param>
        /// <returns>Список значений</returns>
        IEnumerable<GridItem> GetGridValuesByDossierId(int dossierId);

        /// <summary>
        /// Вставление обєктеов
        /// </summary>
        /// <param name="list">Список атрибутов</param>
        /// <returns>ИД основного листа</returns>
        int InsertValuesWithList(IList<AttributeValue> list, int dosierId);

        /// <summary>
        /// Обновление значения обєкта
        /// </summary>
        /// <param name="list">Список атрибутов</param>
        /// <param name="valueId">ИД значения</param>
        void UpdateValues(IList<AttributeValue> list, int valueId);

        /// <summary>
        /// Удаление обєкта по ИД основного листа
        /// </summary>
        /// <param name="mainListId">ИД основного листа</param>
        void DeleteValueByMainListId(int mainListId);

        /// <summary>
        /// Получение ИД первой вкладки обєкта
        /// </summary>
        /// <param name="mainListId">ИД основного листа</param>
        /// <returns>ИД первой вкладки обєкта</returns>
        int GetFirstInsetValueIdByMainListId(int mainListId);

        /// <summary>
        /// Получение ИД значения по основном листу и вкладке
        /// </summary>
        /// <param name="mainListId">ИД основного листа</param>
        /// <param name="insetId">ИД вкладки</param>
        /// <returns>ИД значения обєкта</returns>
        int GetValueIdByMainListAndInsetId(int mainListId, int insetId);

        /// <summary>
        /// Получение ИД вкладки по ИД значению
        /// </summary>
        /// <param name="valueId">ИД значения</param>
        /// <returns>ИД вкладки</returns>
        int GetInsetIdByValueId(int valueId);

        /// <summary>
        /// Получение значения атрибута
        /// </summary>
        /// <param name="valueId">ИД значения</param>
        /// <param name="typeName">тип атрибута</param>
        /// <param name="typeIndex">Индекс атрибута</param>
        /// <returns>значение</returns>
        string GetValueAttrByValueId(int valueId, string typeName, string typeIndex);
    }
}
