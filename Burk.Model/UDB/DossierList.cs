using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DossierList
    {
        [Key]
        public int DosListId { get; set; }

        [ForeignKey("Object")]
        public int? DosObjectId { get; set; }

        [ForeignKey("Inset")]
        public int? DosInsetId { get; set; }

        [ForeignKey("DosList")]
        public int DosListRefId { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateUser { get; set; }

        public DateTime? DeleteDate { get; set; }

        public string DeleteUser { get; set; }

        public DossierObject Object { get; set; }

        public DossierInset Inset { get; set; }

        public DossierList DosList { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0};", DosListId.ToString());
        }
    }
}
