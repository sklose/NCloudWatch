namespace NCloudWatch.Gui
{
    partial class PerformanceCounterSelector
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Panel topDockPanel;
            System.Windows.Forms.Panel fillPanel;
            System.Windows.Forms.Panel bottomDockPanel;
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.instanceComboBox = new System.Windows.Forms.ComboBox();
            this.performanceCounterInfoTextBox = new System.Windows.Forms.TextBox();
            this.counterList = new System.Windows.Forms.ListBox();
            topDockPanel = new System.Windows.Forms.Panel();
            fillPanel = new System.Windows.Forms.Panel();
            bottomDockPanel = new System.Windows.Forms.Panel();
            topDockPanel.SuspendLayout();
            fillPanel.SuspendLayout();
            bottomDockPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topDockPanel
            // 
            topDockPanel.Controls.Add(this.categoryComboBox);
            topDockPanel.Controls.Add(this.instanceComboBox);
            topDockPanel.Dock = System.Windows.Forms.DockStyle.Top;
            topDockPanel.Location = new System.Drawing.Point(0, 0);
            topDockPanel.Name = "topDockPanel";
            topDockPanel.Size = new System.Drawing.Size(469, 42);
            topDockPanel.TabIndex = 3;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(0, 0);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(469, 21);
            this.categoryComboBox.TabIndex = 0;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // instanceComboBox
            // 
            this.instanceComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.instanceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.instanceComboBox.FormattingEnabled = true;
            this.instanceComboBox.Location = new System.Drawing.Point(0, 21);
            this.instanceComboBox.Name = "instanceComboBox";
            this.instanceComboBox.Size = new System.Drawing.Size(469, 21);
            this.instanceComboBox.TabIndex = 2;
            this.instanceComboBox.SelectedIndexChanged += new System.EventHandler(this.instanceComboBox_SelectedIndexChanged);
            // 
            // fillPanel
            // 
            fillPanel.Controls.Add(bottomDockPanel);
            fillPanel.Controls.Add(this.counterList);
            fillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            fillPanel.Location = new System.Drawing.Point(0, 42);
            fillPanel.Name = "fillPanel";
            fillPanel.Size = new System.Drawing.Size(469, 538);
            fillPanel.TabIndex = 4;
            // 
            // bottomDockPanel
            // 
            bottomDockPanel.Controls.Add(this.performanceCounterInfoTextBox);
            bottomDockPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomDockPanel.Location = new System.Drawing.Point(0, 438);
            bottomDockPanel.Name = "bottomDockPanel";
            bottomDockPanel.Size = new System.Drawing.Size(469, 100);
            bottomDockPanel.TabIndex = 3;
            // 
            // performanceCounterInfoTextBox
            // 
            this.performanceCounterInfoTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.performanceCounterInfoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.performanceCounterInfoTextBox.Location = new System.Drawing.Point(0, 0);
            this.performanceCounterInfoTextBox.Multiline = true;
            this.performanceCounterInfoTextBox.Name = "performanceCounterInfoTextBox";
            this.performanceCounterInfoTextBox.ReadOnly = true;
            this.performanceCounterInfoTextBox.Size = new System.Drawing.Size(469, 100);
            this.performanceCounterInfoTextBox.TabIndex = 0;
            // 
            // counterList
            // 
            this.counterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.counterList.FormattingEnabled = true;
            this.counterList.IntegralHeight = false;
            this.counterList.Location = new System.Drawing.Point(0, 0);
            this.counterList.Name = "counterList";
            this.counterList.Size = new System.Drawing.Size(469, 538);
            this.counterList.TabIndex = 2;
            this.counterList.SelectedIndexChanged += new System.EventHandler(this.counterList_SelectedIndexChanged);
            // 
            // PerformanceCounterSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(fillPanel);
            this.Controls.Add(topDockPanel);
            this.Name = "PerformanceCounterSelector";
            this.Size = new System.Drawing.Size(469, 580);
            this.Load += new System.EventHandler(this.PerformanceCounterSelector_Load);
            topDockPanel.ResumeLayout(false);
            fillPanel.ResumeLayout(false);
            bottomDockPanel.ResumeLayout(false);
            bottomDockPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox instanceComboBox;
        private System.Windows.Forms.ListBox counterList;
        private System.Windows.Forms.TextBox performanceCounterInfoTextBox;
    }
}
