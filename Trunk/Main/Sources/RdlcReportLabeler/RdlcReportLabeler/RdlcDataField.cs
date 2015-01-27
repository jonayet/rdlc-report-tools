using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdlcReportLabeler
{
    public class RdlcExpression
    {
        public string ExpressionText { get; set; }
        public List<string> FieldStrings { get; set; }
        public List<RdlcDataField> Fields { get; set; }
        public List<SpacialAttribute> SpacialAttributes { get; set; }
    }

    public class RdlcDataField
    {
        public string Field { get; set; }       
        public string Dataset { get; set; }
    }

    public enum SpacialAttribute
    {
        Iif,
        Switch,
    }
}
