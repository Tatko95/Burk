using System.ComponentModel.DataAnnotations;

namespace Burk.Model.UDB
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
