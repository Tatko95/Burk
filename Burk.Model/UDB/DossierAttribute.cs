using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("DossierAttribute", Schema = "udb")]
    public class DossierAttribute
    {
        [Key]
        public int DosAttributeId { get; set; }

        [ForeignKey("Inset")]
        public int? DosInsetId { get; set; }

        [ForeignKey("Dictionary")]
        public int? DictionaryId { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string ValueName { get; set; }

        public int Index { get; set; }

        public int UID { get; set; }
        
        [NotMapped]
        public AttributeType AttributeType
        {
            get
            {
                if (ValueName.Contains("Text"))
                    return AttributeType.Text;
                else if (ValueName.Contains("Number"))
                    return AttributeType.Number;
                else // if Date
                    return AttributeType.Date;
            }
        }

        [ForeignKey("Grid")]
        public int? GridId { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public DossierGrid Grid { get; set; }

        public Dictionary Dictionary { get; set; }

        public DossierInset Inset { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", DosAttributeId.ToString(), FullName);
        }
    }

    public enum AttributeType
    {
        Text = 1,
        Number = 2,
        Date = 3
    }
}
