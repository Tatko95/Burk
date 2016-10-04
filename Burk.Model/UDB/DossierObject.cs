using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DossierObject
    {
        [Key]
        public int ObjectId { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        [ForeignKey("System")]
        public int? SystemId { get; set; }

        public int UID { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public System System { get; set; }
    }
}
