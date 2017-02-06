using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("Role", Schema = "user")]
    public class Role : IdentityRole<string, UserRole>
    {
        public bool? IsDefault { get; set; }

        [ForeignKey("System")]
        public int? SystemId { get; set; }

        public UDB.System System { get; set; }
    }
}
