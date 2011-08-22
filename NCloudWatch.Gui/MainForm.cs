using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace NCloudWatch.Gui
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the DoWork event of the loadMetricsBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.DoWorkEventArgs"/> instance containing the event data.</param>
        private void loadMetricsBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var client = ManagementServiceClient.Create();
                var list = client.GetMetrics();
                for (int i = 0; i < list.Count; i++)
                {
                    loadMetricsBackgroundWorker.ReportProgress(100 / list.Count * i, list[i]);
                }
            }
            catch (Exception ex)
            {
                loadMetricsBackgroundWorker.ReportProgress(100, ex);
            }
        }

        /// <summary>
        /// Handles the ProgressChanged event of the loadMetricsBackgroundWorker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void loadMetricsBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is Exception)
                toolStripStatusLabel.Text = "Unable to connect to background service";
            else
                toolStripStatusLabel.Text = "Ready ...";

            var metric = e.UserState as PerformanceCounterMetric;
            if (metric != null)
            {
                var converter = TypeDescriptor.GetConverter(typeof(MetricUnit));

                var listItem = new ListViewItem(metric.Name);
                listItem.SubItems.Add(metric.ReportInterval.ToString());
                listItem.SubItems.Add(converter.ConvertToString(metric.Unit));
                listItem.SubItems.Add(metric.PerformanceCounter.Category);
                listItem.SubItems.Add(metric.PerformanceCounter.Name);
                listItem.SubItems.Add(metric.PerformanceCounter.InstanceName);

                metricsListView.Items.Add(listItem);
            }
        }

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {            
            loadMetricsBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the Click event of the refeshToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metricsListView.Items.Clear();
            loadMetricsBackgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Handles the SelectedItemChanged event of the performanceCounterSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void performanceCounterSelector_SelectedItemChanged(object sender, EventArgs e)
        {
            createMetricButton.Enabled = (performanceCounterSelector.SelectedItem != null);
        }

        /// <summary>
        /// Handles the Click event of the createMetricButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void createMetricButton_Click(object sender, EventArgs e)
        {
            var f = new CreateMetricForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                var metric = new PerformanceCounterMetric()
                {
                    Name = f.MetricName,
                    ReportInterval = f.ReportInterval,
                    Unit = f.Unit,
                    PerformanceCounter = performanceCounterSelector.SelectedItem
                };

                try
                {
                    var client = ManagementServiceClient.Create();
                    client.AddMetric(metric);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                refeshToolStripMenuItem_Click(this, new EventArgs());
            }
        }

        /// <summary>
        /// Handles the Click event of the deleteToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (metricsListView.FocusedItem != null &&
                MessageBox.Show("Are you sure?", "Delete Metric", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    var client = ManagementServiceClient.Create();
                    client.RemoveMetric(metricsListView.FocusedItem.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                refeshToolStripMenuItem_Click(this, new EventArgs());
            }
        }

        /// <summary>
        /// Handles the DropDownOpening event of the editToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            deleteToolStripMenuItem.Enabled = (metricsListView.FocusedItem != null);
        }

        /// <summary>
        /// Handles the Click event of the exitToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the awsCredentialsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void awsCredentialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new AwsCredentialsForm();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var client = ManagementServiceClient.Create();
                    client.SetAwsCredentials(f.AccessKeyId, f.SecretAccessKey);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}