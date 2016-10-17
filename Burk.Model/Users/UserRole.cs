using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("UserRole", Schema = "user")]
    public class UserRole : IdentityUserRole
    {
    }
}
