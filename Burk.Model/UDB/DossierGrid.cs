﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DossierGrid
    {
        [Key]
        public int DosGridId { get; set; }

        [ForeignKey("Dictionary")]
        public int? DictionaryId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string GridName { get; set; }

        public int UID { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public virtual Language Language { get; set; }

        public virtual Dictionary Dictionary { get; set; }
    }
}
