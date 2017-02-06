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
                UserRole createrRoleInSystem = new UserRole() { System = system, UserId = userId, RoleId = createrRole.Id, SystemIdIfRoleDefault = obj.SystemId };

                repository.Commit();

                return system;
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw new Exception("Error in Insert System! See innerException", ex);
            }
        }

        public IQueryable<Model.UDB.System> GetAllByUser(string userId)
        {
            IQueryable<Model.UDB.System> result = from usInSys in repository.Table<UserInSystem>().Where(x => x.UserId == userId)
                                                  join sys in repository.Table<Burk.Model.UDB.System>() on usInSys.SystemId equals sys.SystemId
                                                  select sys;
            return result;
        }

        public void Delete(int systemId)
        {
            repository.BeginTransaction();
            try
            {
                Model.UDB.System deleteSystem = GetById("SystemId", systemId.ToString());
                Delete(deleteSystem);
                var userInSystem = repository.Table<UserInSystem>().Where(x => x.SystemId == systemId);
                var roles = repository.Table<Role>().Where(x => x.SystemId == systemId);
                foreach (var user in userInSystem)
                {
                    var userRoles = from rolesO in roles
                                    from userRole in repository.Table<UserRole>().Where(x => x.RoleId == rolesO.Id && x.UserId == user.UserId)
                                    select userRole;

                    foreach (var role in userRoles)
                        repository.Delete(role);
                    repository.Delete(user);
                }
                foreach (var role in roles)
                    repository.Delete(role);
                repository.Commit();
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw new Exception("See InerEx", ex);
            }
        }
        #endregion
    }
}
