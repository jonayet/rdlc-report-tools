using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RdlcReportLabeler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // make settings portable
            var portableSettingsProvider = new PortableSettingsProvider();
            Properties.Settings.Default.Providers.Add(portableSettingsProvider);
            foreach (System.Configuration.SettingsProperty property in Properties.Settings.Default.Properties)
            {
                property.Provider = portableSettingsProvider;
            }
            // make settings portable

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RdlcReportLabelerUi());
        }
    }
}
