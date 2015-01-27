using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RdlcReportLabeler
{
    public class RdlcExpressionParser
    {
        // /First(.*?)\"\)|Fields(.*?).Value/g
        private const string RegexForFieldOnly = @"Fields!(.*?).Value";
        private const string RegexForDatasetOnly = "\"(.*?)\"";
        private const string RegexForFieldWithDataset = @"First\((.*?)\)";

        public RdlcExpression GetParsedRdlcExpression(string rdlcExpressionText)
        {
            var rdlcExpression = new RdlcExpression();
            var regex = new Regex(RegexForFieldOnly + "|" + RegexForFieldWithDataset, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            var matches = regex.Matches(rdlcExpressionText);
            var fieldDataStrings = new List<string>();
            foreach (Match match in matches)
            {
                if (!fieldDataStrings.Exists(s => s == match.Value))
                {
                    fieldDataStrings.Add(match.Value);
                }
            }

            rdlcExpression.ExpressionText = rdlcExpressionText;
            rdlcExpression.FieldStrings = fieldDataStrings;
            rdlcExpression.Fields = MakeDataFields(fieldDataStrings);
            rdlcExpression.SpacialAttributes = CheckSpecialAttributes(rdlcExpressionText);
            return rdlcExpression;
        }

        List<RdlcDataField> MakeDataFields(IEnumerable<string> dataFieldStrings)
        {
            var dataFields = new List<RdlcDataField>();
            foreach (string fieldString in dataFieldStrings)
            {
                var regex = new Regex(RegexForFieldWithDataset, RegexOptions.IgnorePatternWhitespace);
                if (regex.IsMatch(fieldString))
                {
                    regex = new Regex(RegexForFieldOnly, RegexOptions.IgnorePatternWhitespace);
                    string field = regex.Split(fieldString).Count() > 1 ? regex.Split(fieldString)[1] : "";

                    regex = new Regex(RegexForDatasetOnly, RegexOptions.IgnorePatternWhitespace);
                    string dataset = regex.Split(fieldString).Count() > 1 ? regex.Split(fieldString)[1] : "";

                    dataFields.Add(new RdlcDataField
                    {
                        Field = field,
                        Dataset = dataset,
                    });
                }
                else
                {
                    regex = new Regex(RegexForFieldOnly, RegexOptions.IgnorePatternWhitespace);
                    string field = regex.Split(fieldString).Count() > 1 ? regex.Split(fieldString)[1] : "";
                    dataFields.Add(new RdlcDataField
                    {
                        Field = field,
                        Dataset = "",
                    });
                }
            }

            return dataFields;
        }

        List<SpacialAttribute> CheckSpecialAttributes(string expressionText)
        {
            var attributes = new List<SpacialAttribute>();
            string expressionLowerCase = expressionText.ToLower();
            if (expressionLowerCase.Contains("iif"))
            {
                if (!attributes.Exists(a => a == SpacialAttribute.Iif))
                {
                    attributes.Add(SpacialAttribute.Iif);    
                }
            }

            if (expressionLowerCase.Contains("switch"))
            {
                if (!attributes.Exists(a => a == SpacialAttribute.Switch))
                {
                    attributes.Add(SpacialAttribute.Switch);
                }
            }

            if (expressionLowerCase.Contains("lookuptable"))
            {
                if (!attributes.Exists(a => a == SpacialAttribute.Lookup))
                {
                    attributes.Add(SpacialAttribute.Lookup);
                }
            }
            return attributes;
        }
    }
}
