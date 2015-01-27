using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RdlcReportLabeler.Properties;

namespace RdlcReportLabeler
{
    public partial class SettingsUiForm : Form
    {
        public SettingsUiForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
            MessageBox.Show("Saved successful");
        }
    }
}
