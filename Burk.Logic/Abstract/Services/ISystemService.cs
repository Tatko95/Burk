using Burk.Core.Service;
using Burk.Model.Users;
using System;
using System.Linq;

namespace Burk.Logic.Abstract.Services
{
    public interface ISystemService : IBaseService<Model.UDB.System>
    {
        /// <summary>
        /// Создание новой системы
        /// </summary>
        /// <param name="obj">система</param>
        /// <param name="userId">Ид пользователя, который создает систему</param>
        /// <returns>созданая система</returns>
        Model.UDB.System Insert(Model.UDB.System obj, string userId);

        /// <summary>
        /// Получения систем пользователя
        /// </summary>
        /// <param name="userId">Id пользователя</param>
        /// <returns>системы</returns>
        IQueryable<Model.UDB.System> GetAllByUser(string userId);

        /// <summary>
        /// Удаление системы
        /// </summary>
        /// <param name="id">Ид системы</param>
        void Delete(int systemId);
    }
}
