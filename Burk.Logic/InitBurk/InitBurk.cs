using System;
using Burk.Core.Repository;
using Burk.Model.Users;
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
        }
        #endregion
    }
}
