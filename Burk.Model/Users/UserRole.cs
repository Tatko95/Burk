using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("UserRole", Schema = "user")]
    public class UserRole : IdentityUserRole
    {
        /// <summary>
        /// ИД системы, если роль по умолчанию
        /// </summary>
        [ForeignKey("System")]
        public int? SystemIdIfRoleDefault { get; set; }

        public UDB.System System { get; set; }
    }
}
