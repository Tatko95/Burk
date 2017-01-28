using Burk.Core.Service;
using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Abstract.Services;
using Burk.Model.Users;
using System;
using System.Linq;
using Burk.Model.UDB;
using Microsoft.AspNet.Identity;

namespace Burk.Logic.Concrete.Services
{
    public class SystemService : BaseService<Model.UDB.System>, ISystemService, IBaseService<Model.UDB.System>
    {
        #region CTOR
        public SystemService(IBurkModelRepository repo) : base(repo) { }
        #endregion

        #region Methods
        public Model.UDB.System Insert(Model.UDB.System obj, string userId)
        {
            try
            {
                repository.BeginTransaction();
                Model.UDB.System system = repository.Insert(obj);

                var user = repository.Table<User>().FirstOrDefault(x => x.Id == userId);
                UserInSystem userInSystem = new UserInSystem() { System = system, User = user };
                repository.Insert(userInSystem);

                Role createrRole = repository.Table<Role>().FirstOrDefault(x => x.Name == "Creator");
                UserRole createrRoleInSystem = new UserRole() { System = system, UserId = userId, RoleId = createrRole.Id };

                repository.Commit();
                return system;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw new Exception("Error in Insert System! See innerException", ex);
            }
        }

        public override void Delete(Model.UDB.System obj)
        {
            try
            {
                repository.BeginTransaction();
                IQueryable<UserInSystem> userInSystem = repository.Table<UserInSystem>();
                foreach (var user in userInSystem)
                    repository.Delete(user);
                IQueryable<Role> roleInSystem = from rInS in repository.Table<RoleInSystem>().Where(x => x.SystemId == obj.SystemId)
                                                from r in repository.Table<Role>().Where(x => x.Id == rInS.RoleId)
                                                select r;
                foreach (var role in roleInSystem)
                    repository.Delete(role);
                base.Delete(obj);
                repository.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<Model.UDB.System> GetAllByUser(string userId)
        {
            IQueryable<Model.UDB.System> result = from usInSys in repository.Table<UserInSystem>().Where(x => x.UserId == userId)
                                                  join sys in repository.Table<Burk.Model.UDB.System>() on usInSys.SystemId equals sys.SystemId
                                                  select sys;
            return result;
        }
        #endregion
    }
}
