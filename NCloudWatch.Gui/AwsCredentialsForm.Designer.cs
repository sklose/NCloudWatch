namespace NCloudWatch.Gui
{
    partial class AwsCredentialsForm
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
            System.Windows.Forms.Label accessKeyIdLabel;
            System.Windows.Forms.Label secretAccessKeyLabel;
            this.accessKeyIdTextBox = new System.Windows.Forms.TextBox();
            this.secretAccessKeyTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            accessKeyIdLabel = new System.Windows.Forms.Label();
            secretAccessKeyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accessKeyIdLabel
            // 
            accessKeyIdLabel.AutoSize = true;
            accessKeyIdLabel.Location = new System.Drawing.Point(13, 13);
            accessKeyIdLabel.Name = "accessKeyIdLabel";
            accessKeyIdLabel.Size = new System.Drawing.Size(77, 13);
            accessKeyIdLabel.TabIndex = 0;
            accessKeyIdLabel.Text = "Access Key ID";
            // 
            // accessKeyIdTextBox
            // 
            this.accessKeyIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accessKeyIdTextBox.Location = new System.Drawing.Point(13, 30);
            this.accessKeyIdTextBox.Name = "accessKeyIdTextBox";
            this.accessKeyIdTextBox.Size = new System.Drawing.Size(322, 20);
            this.accessKeyIdTextBox.TabIndex = 1;
            // 
            // secretAccessKeyTextBox
            // 
            this.secretAccessKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.secretAccessKeyTextBox.Location = new System.Drawing.Point(12, 80);
            this.secretAccessKeyTextBox.Name = "secretAccessKeyTextBox";
            this.secretAccessKeyTextBox.Size = new System.Drawing.Size(322, 20);
            this.secretAccessKeyTextBox.TabIndex = 3;
            // 
            // secretAccessKeyLabel
            // 
            secretAccessKeyLabel.AutoSize = true;
            secretAccessKeyLabel.Location = new System.Drawing.Point(12, 63);
            secretAccessKeyLabel.Name = "secretAccessKeyLabel";
            secretAccessKeyLabel.Size = new System.Drawing.Size(97, 13);
            secretAccessKeyLabel.TabIndex = 2;
            secretAccessKeyLabel.Text = "Secret Access Key";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(260, 136);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(179, 136);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // AwsCredentialsForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(347, 171);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.secretAccessKeyTextBox);
            this.Controls.Add(secretAccessKeyLabel);
            this.Controls.Add(this.accessKeyIdTextBox);
            this.Controls.Add(accessKeyIdLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AwsCredentialsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Amazon Web Services Credentials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accessKeyIdTextBox;
        private System.Windows.Forms.TextBox secretAccessKeyTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
    }
}