using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("Language", Schema = "udb")]
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        public string Name { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", LanguageId.ToString(), Name);
        }
    }
}
