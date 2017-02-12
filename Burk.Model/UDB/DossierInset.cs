using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Burk.Model.Resources;

namespace Burk.Model.UDB
{
    [Table("DossiertInset", Schema = "udb")]
    public class DossierInset
    {
        [Key]
        public int DosInsetId { get; set; }
        
        [Required]
        [ForeignKey("Object")]
        public int? DosObjectId { get; set; }

        [Required]
        [Display(Name = "FullName", ResourceType = typeof(Resource))]
        public string FullName { get; set; }

        [Display(Name = "ShortName", ResourceType = typeof(Resource))]
        public string ShortName { get; set; }

        public int Index { get; set; }

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
