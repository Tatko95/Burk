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
    } 
}
