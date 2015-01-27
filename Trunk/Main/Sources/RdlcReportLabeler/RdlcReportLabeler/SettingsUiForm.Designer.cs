namespace RdlcReportLabeler
{
    partial class SettingsUiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsUiForm));
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maxFieldsToConcateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fieldLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.maxFieldsToConcateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldLengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field Length:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(201, 217);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(71, 32);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Max. Fields to Concate:";
            // 
            // maxFieldsToConcateNumericUpDown
            // 
            this.maxFieldsToConcateNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maxFieldsToConcateNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::RdlcReportLabeler.Properties.Settings.Default, "MaxFieldsToConcate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.maxFieldsToConcateNumericUpDown.Location = new System.Drawing.Point(139, 39);
            this.maxFieldsToConcateNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxFieldsToConcateNumericUpDown.Name = "maxFieldsToConcateNumericUpDown";
            this.maxFieldsToConcateNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.maxFieldsToConcateNumericUpDown.TabIndex = 5;
            this.maxFieldsToConcateNumericUpDown.Value = global::RdlcReportLabeler.Properties.Settings.Default.MaxFieldsToConcate;
            // 
            // fieldLengthNumericUpDown
            // 
            this.fieldLengthNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fieldLengthNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::RdlcReportLabeler.Properties.Settings.Default, "FieldLength", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fieldLengthNumericUpDown.Location = new System.Drawing.Point(139, 13);
            this.fieldLengthNumericUpDown.Name = "fieldLengthNumericUpDown";
            this.fieldLengthNumericUpDown.Size = new System.Drawing.Size(48, 20);
            this.fieldLengthNumericUpDown.TabIndex = 3;
            this.fieldLengthNumericUpDown.Value = global::RdlcReportLabeler.Properties.Settings.Default.FieldLength;
            // 
            // SettingsUiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.maxFieldsToConcateNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fieldLengthNumericUpDown);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsUiForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.maxFieldsToConcateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldLengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.NumericUpDown fieldLengthNumericUpDown;
        private System.Windows.Forms.NumericUpDown maxFieldsToConcateNumericUpDown;
        private System.Windows.Forms.Label label2;
    }
}