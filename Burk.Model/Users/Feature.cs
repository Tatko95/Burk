using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("Feature", Schema = "user")]
    public class Feature
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
