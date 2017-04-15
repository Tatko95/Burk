using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burk.WebUI.Models
{
    public class GridColumn
    {
        public string text { get; set; }

        public string attributeType { get; set; }

        public bool hidden { get; set; }

        public int width { get; set; }
    }
}