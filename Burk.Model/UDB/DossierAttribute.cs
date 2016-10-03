using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DossierAttribute
    {
        [Key]
        public int AttributeId { get; set; }

        [ForeignKey("Inset")]
        public int? InsetId { get; set; }

        [ForeignKey("Dictionary")]
        public int? DictionaryId { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string ValueName { get; set; }

        public int UID { get; set; }

        [ForeignKey("Grid")]
        public int? GridId { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public DossierGrid Grid { get; set; }

        public Dictionary Dictionary { get; set; }

        public DossierInset Inset { get; set; }
    }
}
