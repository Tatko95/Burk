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
    public interface IDossierService : IBaseService<DossierObject>
    {
        /// <summary>
        /// Получение меню
        /// </summary>
        /// <param name="systemId">ИД системы</param>
        /// <returns>Список елементов</returns>
        List<MenuItem> GetMenuItems(int systemId);

        /// <summary>
        /// Получения меню для его настройки
        /// </summary>
        /// <param name="systemId">ИД системы</param>
        /// <returns>Список елементов + соответствующие настройки</returns>
        List<MenuItem> GetMenuItemsForSettings(int systemId);

        /// <summary>
        /// Вставка либо обновление
        /// </summary>
        /// <param name="model">Модель</param>
        void Upsert(DossierObject model);

        /// <summary>
        /// Поднять пункт меню
        /// </summary>
        /// <param name="dossierId">ИД обєкта</param>
        void UpMenuItem(int dossierId);

        /// <summary>
        /// Опустить пункт меню
        /// </summary>
        /// <param name="dossierId">ИД обєкиа</param>
        void DownMenuItem(int dossierId);
    } 
}
