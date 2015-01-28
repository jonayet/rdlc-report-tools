using System;
using System.Windows.Forms;
using System.Xml;
using RdlcReportLabeler.Properties;

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
            var rdlcXmlString = rdlcXmlInputScintilla.Text;

            // load RDLC XML
            var xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(rdlcXmlString);
            }
            catch (XmlException)
            {
                MessageBox.Show(@"Error in XML!");
                return;
            }

            // get labled!
            string labeledRdlcXmlString;
            try
            {
                labeledRdlcXmlString = new RdlcLabeler().GetLabledRdlcReport(xmlDoc);
                
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message);
                return;
            }

            var reportOutput = new RdlcReportOutputUi(labeledRdlcXmlString);
            reportOutput.ShowDialog();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            new SettingsUiForm().ShowDialog();
        }
    }
}
