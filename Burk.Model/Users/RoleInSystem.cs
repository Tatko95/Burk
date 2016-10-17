using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("RoleInSystem", Schema = "user")]
    public class RoleInSystem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }

        [ForeignKey("System")]
        public int SystemId { get; set; }

        public Role Role { get; set; }

        public Model.UDB.System System { get; set; }
    }
}
