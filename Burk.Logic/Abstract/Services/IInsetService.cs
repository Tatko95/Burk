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
    public interface IInsetService : IBaseService<DossierInset>
    {
        /// <summary>
        /// Получить список вкладок обєкта
        /// </summary>
        /// <param name="dossierId">ИД обєкта</param>
        /// <returns>Список вкладок</returns>
        List<MenuItem> GetInsetItems(int dossierId);

        /// <summary>
        /// Получить список вкладок обєкта для настройки
        /// </summary>
        /// <param name="dossierId">ИД обєкта</param>
        /// <returns>Список вкладок</returns>
        List<MenuItem> GetInsetItemsForSettings(int dossierId);

        /// <summary>
        /// Вставка либо обновление
        /// </summary>
        /// <param name="model">Модель</param>
        void Upsert(DossierInset model);

        /// <summary>
        /// Сдвинуть вкладку вправо
        /// </summary>
        /// <param name="dossierId">ИД вкладки</param>
        void RightInsetItem(int insetId);

        /// <summary>
        /// Сдвинуть вкладку влево
        /// </summary>
        /// <param name="dossierId">ИД вкладки</param>
        void LeftInsetItem(int insetId);
    }
}
