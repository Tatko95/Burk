using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("FeatureInObjectInRole", Schema = "user")]
    public class FeatureInObjectInRole
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }

        [ForeignKey("FeatureInObject")]
        public int FeatureInObjectId { get; set; }

        public Role Role { get; set; }

        public FeatureInObject FeatureInObject { get; set; }
    }
}
