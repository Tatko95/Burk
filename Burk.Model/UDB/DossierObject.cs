﻿using Burk.Model.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    [Table("DossierObject", Schema = "udb")]
    public class DossierObject
    {
        [Key]
        public int DosObjectId { get; set; }

        [Required]
        [Display(Name = "FullName", ResourceType = typeof(Resource))]
        public string FullName { get; set; }

        [Display(Name = "ShortName", ResourceType = typeof(Resource))]
        public string ShortName { get; set; }

        public bool IsDefault { get; set; }

        [Required]
        [ForeignKey("System")]
        public int SystemId { get; set; }

        public int Index { get; set; }

        public int UID { get; set; }

        [ForeignKey("Language")]
        public int? LanguageId { get; set; }

        public Language Language { get; set; }

        public System System { get; set; }

        public override String ToString()
        {
            return string.Format("Id:{0}; Name: {1};", DosObjectId.ToString(), FullName);
        }
    }
}
