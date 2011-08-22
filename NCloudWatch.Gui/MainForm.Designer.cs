namespace NCloudWatch.Gui
{
    partial class MainForm
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
            System.Windows.Forms.SplitContainer splitContainer;
            this.createMetricButton = new System.Windows.Forms.Button();
            this.performanceCounterSelector = new NCloudWatch.Gui.PerformanceCounterSelector();
            this.metricsListView = new System.Windows.Forms.ListView();
            this.metricNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.reportIntervalColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.unitColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.categoryColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.counterColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.instanceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMetricsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.awsCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer.Location = new System.Drawing.Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(this.createMetricButton);
            splitContainer.Panel1.Controls.Add(this.performanceCounterSelector);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(this.metricsListView);
            splitContainer.Size = new System.Drawing.Size(744, 472);
            splitContainer.SplitterDistance = 248;
            splitContainer.TabIndex = 0;
            // 
            // createMetricButton
            // 
            this.createMetricButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createMetricButton.Enabled = false;
            this.createMetricButton.Location = new System.Drawing.Point(12, 440);
            this.createMetricButton.Name = "createMetricButton";
            this.createMetricButton.Size = new System.Drawing.Size(86, 23);
            this.createMetricButton.TabIndex = 1;
            this.createMetricButton.Text = "Create Metric";
            this.createMetricButton.UseVisualStyleBackColor = true;
            this.createMetricButton.Click += new System.EventHandler(this.createMetricButton_Click);
            // 
            // performanceCounterSelector
            // 
            this.performanceCounterSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.performanceCounterSelector.Location = new System.Drawing.Point(3, 3);
            this.performanceCounterSelector.Name = "performanceCounterSelector";
            this.performanceCounterSelector.Size = new System.Drawing.Size(242, 431);
            this.performanceCounterSelector.TabIndex = 0;
            this.performanceCounterSelector.SelectedItemChanged += new System.EventHandler<System.EventArgs>(this.performanceCounterSelector_SelectedItemChanged);
            // 
            // metricsListView
            // 
            this.metricsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.metricNameColumnHeader,
            this.reportIntervalColumnHeader,
            this.unitColumnHeader,
            this.categoryColumnHeader,
            this.counterColumnHeader,
            this.instanceColumnHeader});
            this.metricsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metricsListView.FullRowSelect = true;
            this.metricsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.metricsListView.Location = new System.Drawing.Point(0, 0);
            this.metricsListView.MultiSelect = false;
            this.metricsListView.Name = "metricsListView";
            this.metricsListView.Size = new System.Drawing.Size(492, 472);
            this.metricsListView.TabIndex = 0;
            this.metricsListView.UseCompatibleStateImageBehavior = false;
            this.metricsListView.View = System.Windows.Forms.View.Details;
            // 
            // metricNameColumnHeader
            // 
            this.metricNameColumnHeader.Text = "Name";
            this.metricNameColumnHeader.Width = 160;
            // 
            // reportIntervalColumnHeader
            // 
            this.reportIntervalColumnHeader.Text = "Interval";
            // 
            // unitColumnHeader
            // 
            this.unitColumnHeader.Text = "Unit";
            this.unitColumnHeader.Width = 80;
            // 
            // categoryColumnHeader
            // 
            this.categoryColumnHeader.Text = "Category";
            this.categoryColumnHeader.Width = 120;
            // 
            // counterColumnHeader
            // 
            this.counterColumnHeader.Text = "Counter";
            this.counterColumnHeader.Width = 120;
            // 
            // instanceColumnHeader
            // 
            this.instanceColumnHeader.Text = "Instance";
            this.instanceColumnHeader.Width = 120;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(splitContainer);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(744, 472);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(744, 518);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mainMenuStrip);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(744, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "Ready ...";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel.Text = "Ready ...";
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(744, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.awsCredentialsToolStripMenuItem,
            this.refeshToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // refeshToolStripMenuItem
            // 
            this.refeshToolStripMenuItem.Name = "refeshToolStripMenuItem";
            this.refeshToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.refeshToolStripMenuItem.Text = "&Refesh";
            this.refeshToolStripMenuItem.Click += new System.EventHandler(this.refeshToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // loadMetricsBackgroundWorker
            // 
            this.loadMetricsBackgroundWorker.WorkerReportsProgress = true;
            this.loadMetricsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.loadMetricsBackgroundWorker_DoWork);
            this.loadMetricsBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.loadMetricsBackgroundWorker_ProgressChanged);
            // 
            // awsCredentialsToolStripMenuItem
            // 
            this.awsCredentialsToolStripMenuItem.Name = "awsCredentialsToolStripMenuItem";
            this.awsCredentialsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.awsCredentialsToolStripMenuItem.Text = "AWS &Credentials";
            this.awsCredentialsToolStripMenuItem.Click += new System.EventHandler(this.awsCredentialsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 518);
            this.Controls.Add(this.toolStripContainer1);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "NCloudWatch";
            this.Load += new System.EventHandler(this.MainForm_Load);
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splitContainer)).EndInit();
            splitContainer.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView metricsListView;
        private System.Windows.Forms.ColumnHeader metricNameColumnHeader;
        private System.Windows.Forms.ColumnHeader reportIntervalColumnHeader;
        private System.Windows.Forms.ColumnHeader unitColumnHeader;
        private System.Windows.Forms.ColumnHeader categoryColumnHeader;
        private System.Windows.Forms.ColumnHeader counterColumnHeader;
        private System.Windows.Forms.ColumnHeader instanceColumnHeader;
        private System.ComponentModel.BackgroundWorker loadMetricsBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem refeshToolStripMenuItem;
        private PerformanceCounterSelector performanceCounterSelector;
        private System.Windows.Forms.Button createMetricButton;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem awsCredentialsToolStripMenuItem;

    }
}