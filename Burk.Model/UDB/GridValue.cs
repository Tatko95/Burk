using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Burk.Model.UDB
{
    public class GridValue
    {
        [Key]
        public int GridId { get; set; }

        [ForeignKey("Value")]
        public int? ValueId { get; set; }

        [ForeignKey("Attribute")]
        public int? AttributeId { get; set; }

        public string Text1 { get; set; }

        public string Test2 { get; set; }

        public string Text3 { get; set; }

        public string Text4 { get; set; }

        public string Text5 { get; set; }

        public string Test6 { get; set; }

        public string Text7 { get; set; }

        public string Text8 { get; set; }

        public string Text9 { get; set; }

        public string Test10 { get; set; }

        public string Text11 { get; set; }

        public string Text12 { get; set; }

        public string Text13 { get; set; }

        public string Test14 { get; set; }

        public string Text15 { get; set; }

        public string Text16 { get; set; }

        public string Text17 { get; set; }

        public string Test18 { get; set; }

        public string Text19 { get; set; }

        public string Text20 { get; set; }

        public DateTime? Date1 { get; set; }

        public DateTime? Date2 { get; set; }

        public DateTime? Date3 { get; set; }

        public DateTime? Date4 { get; set; }

        public DateTime? Date5 { get; set; }

        public DateTime? Date6 { get; set; }

        public DateTime? Date7 { get; set; }

        public DateTime? Date8 { get; set; }

        public DateTime? Date9 { get; set; }

        public DateTime? Date10 { get; set; }

        public int Number1 { get; set; }

        public int Number2 { get; set; }

        public int Number3 { get; set; }

        public int Number4 { get; set; }

        public int Number5 { get; set; }

        public int Number6 { get; set; }

        public int Number7 { get; set; }

        public int Number8 { get; set; }

        public int Number9 { get; set; }

        public int Number10 { get; set; }

        public int Number11 { get; set; }

        public int Number12 { get; set; }

        public int Number13 { get; set; }

        public int Number14 { get; set; }

        public int Number15 { get; set; }

        public int Number16 { get; set; }

        public int Number17 { get; set; }

        public int Number18 { get; set; }

        public int Number19 { get; set; }

        public int Number20 { get; set; }

        public DossierAttribute Attribute { get; set; }

        public DossierValue Value { get; set; }
    }
}
