using Burk.Model.Resources;
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

        [Required]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string AttributeTypeName { get; set; }
        
        public int AttributeTypeIndex { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        [Display(Name = "ShowInGrid", ResourceType = typeof(Resource))]
        public bool IsShowInGrid { get; set; }

        public int UID { get; set; }
        
        [NotMapped]
        [Display(Name = "AttributeType", ResourceType = typeof(Resource))]
        public AttributeType AttributeType
        {
            get
            {
                if (string.IsNullOrEmpty(AttributeTypeName))
                    return AttributeType.Unknow;
                else if (AttributeTypeName.Contains("Text"))
                    return AttributeType.Text;
                else if (AttributeTypeName.Contains("Number"))
                    return AttributeType.Number;
                else if (AttributeTypeName.Contains("Date"))
                    return AttributeType.Date;
                return AttributeType.Unknow;
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
        Unknow = 0,
        Text = 1,
        Number = 2,
        Date = 3
    }
}
