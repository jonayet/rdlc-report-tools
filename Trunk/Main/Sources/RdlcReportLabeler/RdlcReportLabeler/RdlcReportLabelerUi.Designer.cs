namespace RdlcReportLabeler
{
    partial class RdlcReportLabelerUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RdlcReportLabelerUi));
            this.doLabelingButton = new System.Windows.Forms.Button();
            this.rdlcXmlInputScintilla = new ScintillaNET.Scintilla();
            this.settingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rdlcXmlInputScintilla)).BeginInit();
            this.SuspendLayout();
            // 
            // doLabelingButton
            // 
            this.doLabelingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.doLabelingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doLabelingButton.Location = new System.Drawing.Point(657, 627);
            this.doLabelingButton.Name = "doLabelingButton";
            this.doLabelingButton.Size = new System.Drawing.Size(123, 39);
            this.doLabelingButton.TabIndex = 1;
            this.doLabelingButton.Text = "Start Labeling";
            this.doLabelingButton.UseVisualStyleBackColor = true;
            this.doLabelingButton.Click += new System.EventHandler(this.doLabelingButton_Click);
            // 
            // rdlcXmlInputScintilla
            // 
            this.rdlcXmlInputScintilla.ConfigurationManager.Language = "xml";
            this.rdlcXmlInputScintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rdlcXmlInputScintilla.Location = new System.Drawing.Point(0, 0);
            this.rdlcXmlInputScintilla.Margins.Margin0.Width = 40;
            this.rdlcXmlInputScintilla.Name = "rdlcXmlInputScintilla";
            this.rdlcXmlInputScintilla.Size = new System.Drawing.Size(830, 704);
            this.rdlcXmlInputScintilla.Styles.BraceBad.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.BraceLight.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.CallTip.FontName = "Segoe UI\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.ControlChar.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.rdlcXmlInputScintilla.Styles.Default.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.IndentGuide.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.LastPredefined.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.LineNumber.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.Styles.Max.FontName = "Verdana\0\0\0\0\0\0\0\0\0\0\0\0\0";
            this.rdlcXmlInputScintilla.TabIndex = 2;
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(705, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(75, 23);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // RdlcReportLabelerUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 704);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.doLabelingButton);
            this.Controls.Add(this.rdlcXmlInputScintilla);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RdlcReportLabelerUi";
            this.Text = "RDLC Report Labeler";
            ((System.ComponentModel.ISupportInitialize)(this.rdlcXmlInputScintilla)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button doLabelingButton;
        private ScintillaNET.Scintilla rdlcXmlInputScintilla;
        private System.Windows.Forms.Button settingsButton;
    }
}

