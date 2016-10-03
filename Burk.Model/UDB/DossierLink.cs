using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DossierLink
    {
        [Key]
        public int LinkId { get; set; }

        [ForeignKey("List1")]
        public int? List1Id { get; set; }

        [ForeignKey("List2")]
        public int? List2Id { get; set; }

        public DossierList List1 { get; set; }

        public DossierList List2 { get; set; }
    }
}
