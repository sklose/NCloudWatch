namespace NCloudWatch.Gui
{
    partial class CreateMetricForm
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
            System.Windows.Forms.Label metricNameLabel;
            System.Windows.Forms.Label unitLabel;
            System.Windows.Forms.Label intervalLabel;
            this.metricNameTextBox = new System.Windows.Forms.TextBox();
            this.unitComboBox = new System.Windows.Forms.ComboBox();
            this.intervalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            metricNameLabel = new System.Windows.Forms.Label();
            unitLabel = new System.Windows.Forms.Label();
            intervalLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // metricNameLabel
            // 
            metricNameLabel.AutoSize = true;
            metricNameLabel.Location = new System.Drawing.Point(12, 13);
            metricNameLabel.Name = "metricNameLabel";
            metricNameLabel.Size = new System.Drawing.Size(70, 13);
            metricNameLabel.TabIndex = 0;
            metricNameLabel.Text = "Metric Name:";
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.Location = new System.Drawing.Point(12, 62);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new System.Drawing.Size(29, 13);
            unitLabel.TabIndex = 2;
            unitLabel.Text = "Unit:";
            // 
            // intervalLabel
            // 
            intervalLabel.AutoSize = true;
            intervalLabel.Location = new System.Drawing.Point(12, 112);
            intervalLabel.Name = "intervalLabel";
            intervalLabel.Size = new System.Drawing.Size(45, 13);
            intervalLabel.TabIndex = 5;
            intervalLabel.Text = "Interval:";
            // 
            // metricNameTextBox
            // 
            this.metricNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metricNameTextBox.Location = new System.Drawing.Point(12, 29);
            this.metricNameTextBox.Name = "metricNameTextBox";
            this.metricNameTextBox.Size = new System.Drawing.Size(259, 20);
            this.metricNameTextBox.TabIndex = 1;
            // 
            // unitComboBox
            // 
            this.unitComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unitComboBox.FormattingEnabled = true;
            this.unitComboBox.Location = new System.Drawing.Point(12, 79);
            this.unitComboBox.Name = "unitComboBox";
            this.unitComboBox.Size = new System.Drawing.Size(259, 21);
            this.unitComboBox.TabIndex = 3;
            // 
            // intervalDateTimePicker
            // 
            this.intervalDateTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalDateTimePicker.CustomFormat = "HH:mm:ss";
            this.intervalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.intervalDateTimePicker.Location = new System.Drawing.Point(12, 128);
            this.intervalDateTimePicker.Name = "intervalDateTimePicker";
            this.intervalDateTimePicker.ShowUpDown = true;
            this.intervalDateTimePicker.Size = new System.Drawing.Size(259, 20);
            this.intervalDateTimePicker.TabIndex = 4;
            this.intervalDateTimePicker.Value = new System.DateTime(2001, 1, 1, 0, 1, 0, 0);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(195, 178);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(114, 178);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // CreateMetricForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(283, 213);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(intervalLabel);
            this.Controls.Add(this.intervalDateTimePicker);
            this.Controls.Add(this.unitComboBox);
            this.Controls.Add(unitLabel);
            this.Controls.Add(this.metricNameTextBox);
            this.Controls.Add(metricNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateMetricForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Metric";
            this.Load += new System.EventHandler(this.CreateMetricForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox metricNameTextBox;
        private System.Windows.Forms.ComboBox unitComboBox;
        private System.Windows.Forms.DateTimePicker intervalDateTimePicker;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}