using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("RoleInUser", Schema = "user")]
    public class RoleInUser
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
