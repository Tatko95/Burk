using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("UserInSystem", Schema = "user")]
    public class UserInSystem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("System")]
        public int SystemId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public UDB.System System { get; set; }

        public User User { get; set; }
    }
}
