using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("Role", Schema = "user")]
    public class Role : IdentityRole<string, UserRole>
    {
    }
}
