using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Burk.Model.UDB
{
    [Table("DossiertInset", Schema = "udb")]
    public class DossierInset
    {
        [Key]
        public int DosInsetId { get; set; }

        [ForeignKey("Object")]
        public int? DosObjectId { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int UID { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public DossierObject Object { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", DosInsetId.ToString(), FullName);
        }
    }
}
