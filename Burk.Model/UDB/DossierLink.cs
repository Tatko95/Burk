
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("DossierLink", Schema = "udb")]
    public class DossierLink
    {
        [Key]
        public int DosLinkId { get; set; }

        [ForeignKey("List1")]
        public int? DosList1Id { get; set; }

        [ForeignKey("List2")]
        public int? DosList2Id { get; set; }

        public DossierList List1 { get; set; }

        public DossierList List2 { get; set; }

        public override String ToString()
        {
            return string.Format("ListId:{0}; Id1:{1}; Id2:{2};", DosLinkId.ToString(), DosList1Id.ToString(), DosList2Id.ToString());
        }
    }
}
