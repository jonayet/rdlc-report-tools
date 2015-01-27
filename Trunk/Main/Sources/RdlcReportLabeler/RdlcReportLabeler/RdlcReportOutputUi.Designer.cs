namespace RdlcReportLabeler
{
    partial class RdlcReportOutputUi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RdlcReportOutputUi));
            this.rdlcXmlOutputScintilla = new ScintillaNET.Scintilla();
            ((System.ComponentModel.ISupportInitialize)(this.rdlcXmlOutputScintilla)).BeginInit();
            this.SuspendLayout();
            // 
            // rdlcXmlOutputScintilla
            // 
            this.rdlcXmlOutputScintilla.ConfigurationManager.Language = "xml";
            this.rdlcXmlOutputScintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdlcXmlOutputScintilla.Location = new System.Drawing.Point(0, 0);
            this.rdlcXmlOutputScintilla.Margins.Margin0.Width = 50;
            this.rdlcXmlOutputScintilla.Name = "rdlcXmlOutputScintilla";
            this.rdlcXmlOutputScintilla.Size = new System.Drawing.Size(830, 704);
            this.rdlcXmlOutputScintilla.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.rdlcXmlOutputScintilla.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlOutputScintilla.TabIndex = 3;
            // 
            // RdlcReportOutputUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 704);
            this.Controls.Add(this.rdlcXmlOutputScintilla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RdlcReportOutputUi";
            this.Text = "RDLC Report Labeler";
            ((System.ComponentModel.ISupportInitialize)(this.rdlcXmlOutputScintilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNET.Scintilla rdlcXmlOutputScintilla;



    }
}

