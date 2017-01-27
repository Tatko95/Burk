using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("System", Schema = "udb")]
    public class System
    {
        [Key]
        public int SystemId { get; set; }

        [Required]
        [Display(Name = "FullName")]
        public string FullName { get; set; }

        [Display(Name = "ShortName")]
        public string ShortName { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public int UID { get; set; }

        public virtual Language Language { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", SystemId.ToString(), FullName);
        }
    }
}
