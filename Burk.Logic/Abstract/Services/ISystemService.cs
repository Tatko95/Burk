using Burk.Core.Service;
using Burk.Model.Users;
using System;

namespace Burk.Logic.Abstract.Services
{
    public interface ISystemService : IBaseService<Model.UDB.System>
    {
        /// <summary>
        /// Создание новой системы
        /// </summary>
        /// <param name="obj">система</param>
        /// <param name="user">пользователь, который создает систему</param>
        /// <returns>созданая система</returns>
        Model.UDB.System Insert(Model.UDB.System obj, User user);
    }
}
