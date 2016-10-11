using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("DictionaryAttribute", Schema = "udb")]
    public class DictionaryAttribute
    {
        [Key]
        public int DicAttributeId { get; set; }

        [ForeignKey("Dictionary")]
        public int? DictionaryId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int UID { get; set; }

        //Ref
        [ForeignKey("DicAttribute")]
        public int DicAttributeLevelRefId { get; set; }

        //public int DicAttributeTypeId { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public Dictionary Dictionary { get; set; }

        public DictionaryAttribute DicAttribute { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", DicAttributeId.ToString(), FullName);
        }
    }
}
