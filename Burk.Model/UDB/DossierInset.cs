using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DossierInset
    {
        [Key]
        public int InsetId { get; set; }

        [ForeignKey("Object")]
        public int? ObjectId { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int UID { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public DossierObject Object { get; set; }
    }
}
