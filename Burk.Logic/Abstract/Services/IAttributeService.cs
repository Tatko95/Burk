using Burk.Core.Service;
using Burk.Model.UDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burk.Logic.Abstract.Services
{
    public interface IAttributeService : IBaseService<DossierAttribute>
    {
        /// <summary>
        /// Вставка атрибута в БД
        /// </summary>
        /// <param name="attr">Обект атрибута</param>
        /// <returns>Вставленный обект</returns>
        DossierAttribute InsertAttribute(DossierAttribute attr);

        /// <summary>
        /// Обновление координат атрибута, после его перемещения
        /// </summary>
        /// <param name="attrId">ИД атрибута</param>
        /// <param name="x">Координата Х</param>
        /// <param name="y">Координата У</param>
        void UpdatePositionAttribute(int attrId, int x, int y);

        /// <summary>
        /// Обновление размеров атрибута, после его resizable
        /// </summary>
        /// <param name="attrId">ИД аттрибута</param>
        /// <param name="width">Ширина</param>
        /// <param name="height">Высота</param>
        void UpdateSizeAttribute(int attrId, int width, int height);

        /// <summary>
        /// Получения всех атрибуттов   
        /// </summary>
        /// <param name="dosInsetId">ИД вкладки</param>
        /// <returns>Список атрибутов</returns>
        IQueryable<DossierAttribute> GetAllAttributes(int dosInsetId);
    }
}
