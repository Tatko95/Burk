using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("DictionaryValue", Schema = "udb")]
    public class DictionaryValue
    {
        [Key]
        public int DicValueId { get; set; }

        [ForeignKey("DicAttribute")]
        public int? DicAttributeId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int UID { get; set; }

        [Required]
        [ForeignKey("Dictionary")]
        public int DictionaryId { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public virtual DictionaryAttribute DicAttribute { get; set; }

        public virtual Dictionary Dictionary { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", DicValueId.ToString(), FullName);
        }
    }
}
