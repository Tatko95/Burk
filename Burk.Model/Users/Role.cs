using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    public class Role : IdentityRole<string, UserRole>
    {
        [ForeignKey("System")]
        public int SystemId { get; set; }

        public UDB.System System { get; set; }
    }
}
