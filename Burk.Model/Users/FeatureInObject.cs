using Burk.Model.UDB;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.Users
{
    [Table("FeatureInObject", Schema = "user")]
    public class FeatureInObject
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Object")]
        public int DossierObjectId { get; set; }

        [ForeignKey("DicValue")]
        public int DicValueId { get; set; }

        public DossierObject Object { get; set; }

        public DictionaryValue DicValue { get; set; }
    }
}
