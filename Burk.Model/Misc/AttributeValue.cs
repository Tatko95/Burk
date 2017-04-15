using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burk.Model.Misc
{
    public class AttributeValue
    {
        public string AttributeTypeName { get; set; }
        public int AttributeTypeIndex { get; set; }
        public int InsetId { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return AttributeTypeName + " " + AttributeTypeIndex.ToString() + " " + InsetId.ToString() + " ";
        }
    }
}
