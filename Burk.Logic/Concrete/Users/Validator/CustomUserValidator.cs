using Burk.Core.Repository;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Model.Users;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Burk.Logic.Concrete.Users.Validator
{
    public class CustomUserValidator : UserValidator<User>
    {
        private IBaseRepository repository = null;

        public CustomUserValidator(ApplicationUserManager mgr, IBaseRepository repo) : base(mgr)
        {
            AllowOnlyAlphanumericUserNames = true;
            repository = repo;
        }

        public override async Task<IdentityResult> ValidateAsync(User user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            if (repository.Table<User>().Any(x => x.UserName == user.UserName))
            {
                var errors = result.Errors.ToList();
                errors.Add("Пользователь с таким ником уже существует");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}
