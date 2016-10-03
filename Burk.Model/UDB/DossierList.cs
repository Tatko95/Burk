using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DossierList
    {
        [Key]
        public int ListId { get; set; }

        [ForeignKey("Object")]
        public int? ObjectId { get; set; }

        [ForeignKey("Inset")]
        public int? InsetId { get; set; }

        //public int ListRefId { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CreateUser { get; set; }

        public DateTime? DeleteDate { get; set; }

        public string DeleteUser { get; set; }

        public DossierObject Object { get; set; }

        public DossierInset Inset { get; set; }
    }
}
