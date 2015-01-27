using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;

namespace RdlcReportLabeler
{
    public class RdlcLabeler
    {
        private const string XmlNamespace1 = "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition";
        private const string XmlNamespace2 = "http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition";
        private const int MaxFieldsToConcate = 3;
        private readonly int _maxFieldLength = 10;
        private string _xmlNamespace = "";

        public RdlcLabeler()
        {
            _maxFieldLength = (int) Properties.Settings.Default.FieldLength;
        }

        public string GetLabledRdlcReport(XmlDocument xmlDoc)
        {
            // create ns manager
            var xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            xmlnsManager.AddNamespace("ns1", XmlNamespace1);
            xmlnsManager.AddNamespace("ns2", XmlNamespace2);

            // pre-check for "TextRun" element
            if (xmlDoc.DocumentElement == null) { throw new ApplicationException("Empty XML doc!"); }
            var textRuns = xmlDoc.DocumentElement.SelectNodes("//ns1:TextRun", xmlnsManager);
            _xmlNamespace = XmlNamespace1;
            if (textRuns == null || textRuns.Count == 0)
            {
                textRuns = xmlDoc.DocumentElement.SelectNodes("//ns2:TextRun", xmlnsManager);
                _xmlNamespace = XmlNamespace2;
                if (textRuns == null || textRuns.Count == 0)
                {
                    throw new ApplicationException("No TextRun elemment found!");
                }
            }

            foreach (XmlNode xmlNode in textRuns)
            {
                if (xmlNode.HasChildNodes)
                {
                    XmlElement valueElement = xmlNode["Value"];
                    if (valueElement != null)
                    {
                        string expression = valueElement.InnerText;
                        if (!string.IsNullOrEmpty(expression))
                        {
                            RdlcExpression aRdlcExpression = new RdlcExpressionParser().GetParsedRdlcExpression(expression);
                            if (aRdlcExpression.Fields.Count > 0)
                            {
                                var labelElement = xmlNode["Label"];
                                if (labelElement == null)
                                {
                                    var labelText = BuildLabelText(aRdlcExpression);
                                    if (!string.IsNullOrWhiteSpace(labelText))
                                    {
                                        labelElement = xmlDoc.CreateElement("Label", _xmlNamespace);
                                        labelElement.InnerText = labelText;
                                        xmlNode.InsertBefore(labelElement, valueElement);
                                    }
                                }
                                else
                                {
                                    
                                }
                            }
                        }
                    }
                }
            }

            var settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace,
                Encoding = new UTF8Encoding(false)
            };

            string xmlString;
            using (var memoryStream = new MemoryStream())
            using (var writer = XmlWriter.Create(memoryStream, settings))
            {
                xmlDoc.Save(writer);
                xmlString = Encoding.UTF8.GetString(memoryStream.ToArray());
                writer.Flush();
                writer.Close();
                memoryStream.Flush();
                memoryStream.Close();
                memoryStream.Dispose();
            }

            
            return xmlString;
        }

        string BuildLabelText(RdlcExpression rdlcExpression)
        {
            bool hasLookup = rdlcExpression.SpacialAttributes.Exists(a => a == SpacialAttribute.Lookup);
            bool hasIif = rdlcExpression.SpacialAttributes.Exists(a => a == SpacialAttribute.Iif);
            bool hasSwitch = rdlcExpression.SpacialAttributes.Exists(a => a == SpacialAttribute.Switch);
            string labelText = "";
            for (int i = 0; i < rdlcExpression.Fields.Count && i < MaxFieldsToConcate; i++)
            {
                var fieldText = rdlcExpression.Fields[i].Field;
                if (fieldText.Length <= 0) { continue; }
                if (i != 0 ) { labelText += "_"; }

                // shorten length
                if (_maxFieldLength > 0 && fieldText.Length > _maxFieldLength)
                {
                    fieldText = fieldText.Substring(0, _maxFieldLength);
                }

                if (hasLookup)
                {
                    labelText += fieldText.Substring(0, 1).ToUpper() + fieldText.Substring(1);

                }
                else
                {
                    labelText += fieldText.Substring(0, 1).ToLower() + fieldText.Substring(1);
                }
            }
            return labelText;
        }
    }
}
