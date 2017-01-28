using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Burk.Model.Resources;

namespace Burk.Model.UDB
{
    [Table("System", Schema = "udb")]
    public class System
    {
        [Key]
        public int SystemId { get; set; }

        [Required]
        [Display(Name = "FullName", ResourceType = typeof(Resource))]
        public string FullName { get; set; }

        [Display(Name = "ShortName", ResourceType = typeof(Resource))]
        public string ShortName { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public int UID { get; set; }

        public virtual Language Language { get; set; }

        public override String ToString()
        {
            return string.Format("SystemId:{0}; FullName: {1}; UID: {2}", SystemId.ToString(), FullName, UID.ToString());
        }
    }
}
