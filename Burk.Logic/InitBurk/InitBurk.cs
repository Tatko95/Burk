using System;
using Burk.Core.Repository;
using Burk.Model.Users;
using Burk.Model.UDB;
using System.Linq;
using Burk.Logic.Abstract.Repositories;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Burk.Logic.Concrete.Users.Managers;

namespace Burk.Logic.InitBurk
{
    public class InitBurk : IInitBurk
    {
        #region Fields
        private IBaseRepository repository = null;
        #endregion

        #region CTOR
        public InitBurk(IBurkModelRepository repo)
        {
            repository = repo;
        }
        #endregion

        #region Methods
        public void Init()
        {
            if (!repository.Table<User>().Any(x => x.UserName == "db_developer"))
            {
                //create User
            }
            if (!repository.Table<Role>().Any(x => x.Name == "Creator"))
            {
                Role creator = new Role() { IsDefault = true, Name = "Creator", Id = Guid.NewGuid().ToString() };
                repository.Insert(creator);
            }
            if (!repository.Table<Language>().Any(x => x.Name == "ru" || x.Name == "ua" || x.Name == "en"))
            {
                Language en = new Language() { LanguageId = 1, Name = "en" };
                Language ua = new Language() { LanguageId = 2, Name = "ua" };
                Language ru = new Language() { LanguageId = 3, Name = "ru" };
                repository.Insert(en);
                repository.Insert(ua);
                repository.Insert(ru);
            }
        }
        #endregion
    }
}
