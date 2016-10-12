using Burk.Model.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace Burk.Model.Users.Init
{
    public class ApplicationUserStore : UserStore<User, Role, string, UserLogin, UserRole, UserClaim>, IUserStore<User>, IDisposable
    {
        public ApplicationUserStore(ModelContext context) : base(context) { }
    }
}
