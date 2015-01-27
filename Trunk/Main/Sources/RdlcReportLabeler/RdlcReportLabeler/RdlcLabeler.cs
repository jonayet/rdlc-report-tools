using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using RdlcReportLabeler.Properties;

namespace RdlcReportLabeler
{
    public class RdlcLabeler
    {
        private readonly string[] _xmlNamespaces = {"http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition", "http://schemas.microsoft.com/sqlserver/reporting/2010/01/reportdefinition"};
        private readonly string[] _nsPrefixes = { "ns1", "ns2" };
        private readonly int _maxFieldsToConcate = 3;
        private readonly int _maxFieldLength;
        private string _xmlNamespace = "";
        private string _xmlPrefix = "";


        public RdlcLabeler()
        {
            _maxFieldLength = (int) Settings.Default.FieldLength;
            _maxFieldsToConcate = (int) Settings.Default.MaxFieldsToConcate;
        }

        public string GetLabledRdlcReport(XmlDocument xmlDoc)
        {
            // create ns manager
            var xmlnsManager = new XmlNamespaceManager(xmlDoc.NameTable);
            xmlnsManager.AddNamespace(_nsPrefixes[0], _xmlNamespaces[0]);
            xmlnsManager.AddNamespace(_nsPrefixes[1], _xmlNamespaces[1]);

            // pre-check for "TextRun" element
            if (xmlDoc.DocumentElement == null)
            {
                throw new ApplicationException("Empty XML doc!");
            }

            XmlNodeList tablixes = null;
            for (var i = 0; i < _xmlNamespaces.Length; i++)
            {
                _xmlPrefix = _nsPrefixes[i];
                _xmlNamespace = _xmlNamespaces[i];
                tablixes = xmlDoc.DocumentElement.SelectNodes("//" + _xmlPrefix + ":" + "Tablix", xmlnsManager);
                if (tablixes != null && tablixes.Count > 0) { break; }
            }
            if (tablixes == null || tablixes.Count == 0) { throw new ApplicationException("No Tablix elemment found!"); }

            XmlNode n = tablixes[0];
            n.ParentNode.RemoveChild(n);

            foreach (XmlNode tablixNode in tablixes)
            {
                XmlElement dataSetNameElement = tablixNode["DataSetName"];
                var tablixDatasetName = "";
                if (dataSetNameElement != null) { tablixDatasetName = dataSetNameElement.InnerText; }

                var textRuns = tablixNode.SelectNodes("//" + _xmlPrefix + ":" + "TextRun", xmlnsManager);
                if (textRuns == null) { continue; }

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
                                RdlcExpression aRdlcExpression = new RdlcExpressionParser().GetParsedRdlcExpression(expression, tablixDatasetName);
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
            bool hasIif = rdlcExpression.SpacialAttributes.Exists(a => a == SpacialAttribute.Iif);
            bool hasSwitch = rdlcExpression.SpacialAttributes.Exists(a => a == SpacialAttribute.Switch);
            string labelText = "";
            for (int i = 0; i < rdlcExpression.Fields.Count && i < _maxFieldsToConcate; i++)
            {
                var fieldText = rdlcExpression.Fields[i].Field;
                var datasetName = rdlcExpression.Fields[i].Dataset;
                if (fieldText.Length == 0) { continue; }
                if (i != 0 ) { labelText += "_"; }

                // shorten length
                if (_maxFieldLength > 0 && fieldText.Length > _maxFieldLength)
                {
                    fieldText = fieldText.Substring(0, _maxFieldLength);
                }

                if (datasetName.Equals("LookupTable"))
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
