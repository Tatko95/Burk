﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class DictionaryAttribute
    {
        [Key]
        public int DicAttributeId { get; set; }

        [ForeignKey("Dictionary")]
        public int? DictionaryId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int UID { get; set; }

        //Ref
        public int DicAttributeRefId { get; set; }

        //public int DicAttributeTypeId { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public Dictionary Dictionary { get; set; }
    }
}