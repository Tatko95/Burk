using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("Dictionary", Schema = "udb")]
    public class Dictionary
    {
        [Key]
        public int DictionaryId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int UID { get; set; }

        [ForeignKey("System")]
        public int? SystemId { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public virtual System System { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", DictionaryId.ToString(), FullName);
        }
    }
}
