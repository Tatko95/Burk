using System;
using System.ComponentModel.DataAnnotations;

namespace Burk.Model.UDB
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        public string Name { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", LanguageId.ToString(), Name);
        }
    }
}
