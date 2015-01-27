using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RdlcReportLabeler
{
    public partial class RdlcReportLabelerUi : Form
    {
        

        public RdlcReportLabelerUi()
        {
            InitializeComponent();
        }

        private void doLabelingButton_Click(object sender, EventArgs e)
        {
            // load RDLC XML
            var xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(rdlcXmlInputScintilla.Text);
            }
            catch (XmlException)
            {
                MessageBox.Show("Error in XML!");
                return;
            }

            string labeledRdlcXml = "";
            try
            {
                labeledRdlcXml = new RdlcLabeler().GetLabledRdlcReport(xmlDoc);
                
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message);
                return;
            }

            var reportOutput = new RdlcReportOutputUi(labeledRdlcXml);
            reportOutput.ShowDialog();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new SettingsUiForm().ShowDialog();
        }
    }
}
