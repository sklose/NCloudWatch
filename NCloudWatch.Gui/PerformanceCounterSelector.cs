using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace NCloudWatch.Gui
{
    public partial class PerformanceCounterSelector : UserControl
    {
        private class PerformanceCounterListItem
        {
            /// <summary>
            /// Gets or sets the text.
            /// </summary>
            /// <value>The text.</value>
            public string Text { get; set; }

            /// <summary>
            /// Gets or sets the help.
            /// </summary>
            /// <value>The help.</value>
            public string Help { get; set; }

            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return Text;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceCounterSelector"/> class.
        /// </summary>
        public PerformanceCounterSelector()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the PerformanceCounterSelector control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PerformanceCounterSelector_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadPerformanceCounterCategories();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the categoryComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInstances();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the instanceComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void instanceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPerformanceCounters();
        }

        /// <summary>
        /// Handles the 1 event of the counterList_SelectedIndexChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void counterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (counterList.SelectedItem != null)
            {
                var item = counterList.SelectedItem as PerformanceCounterListItem;
                performanceCounterInfoTextBox.Text = item.Help;
            }
            else
            {
                performanceCounterInfoTextBox.Clear();
            }

            OnSelectedItemChanged(new EventArgs());
        }

        /// <summary>
        /// Gets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public PerformanceCounterDescription SelectedItem
        {
            get
            {
                if (counterList.SelectedItem != null)
                {
                    return new PerformanceCounterDescription()
                    {
                        Name = (counterList.SelectedItem as PerformanceCounterListItem).Text,
                        Category = categoryComboBox.SelectedItem as string,
                        InstanceName = (instanceComboBox.SelectedIndex > 0 ? instanceComboBox.SelectedItem as string : null)
                    };
                }

                return null;
            }
        }

        /// <summary>
        /// Occurs when selected item changed.
        /// </summary>
        public event EventHandler<EventArgs> SelectedItemChanged;

        /// <summary>
        /// Raises the <see cref="E:SelectedItemChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSelectedItemChanged(EventArgs e)
        {
            var evnt = SelectedItemChanged;
            if (evnt != null)
            {
                evnt(this, e);
            }
        }

        private void LoadPerformanceCounterCategories()
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            //
            // Enumerates the categories on a background thread
            //
            worker.DoWork += (sender, e) =>
            {
                foreach (var item in PerformanceCounterCategory.GetCategories().OrderBy(c => c.CategoryName))
                    worker.ReportProgress(0, item.CategoryName);
            };

            //
            // Adds categories to drop down list
            //
            worker.ProgressChanged += (sender, e) =>
            {
                categoryComboBox.Items.Add(e.UserState);
            };

            //
            // Cleans up UI
            //
            worker.RunWorkerCompleted += (sender, e) =>
            {
                Cursor = Cursors.Default;
                if (categoryComboBox.Items.Count > 0)
                    categoryComboBox.SelectedIndex = 0;
            };

            Cursor = Cursors.WaitCursor;
            categoryComboBox.Items.Clear();
            counterList.Items.Clear();
            instanceComboBox.Items.Clear();

            worker.RunWorkerAsync();
        }

        private void LoadInstances()
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            //
            // Enumerates the instances on a background thread
            //
            worker.DoWork += (sender, e) =>
            {
                string name = e.Argument as string;
                worker.ReportProgress(0, "<unnamed>");
                var instances = new PerformanceCounterCategory(name).GetInstanceNames();
                foreach (var item in instances.OrderBy(i => i))
                    worker.ReportProgress(0, item);
            };

            //
            // Adds instances to drop down list
            //
            worker.ProgressChanged += (sender, e) =>
            {
                instanceComboBox.Items.Add(e.UserState);
            };

            //
            // Cleans up UI
            //
            worker.RunWorkerCompleted += (sender, e) =>
            {
                Cursor = Cursors.Default;
                if (instanceComboBox.Items.Count > 0)
                    instanceComboBox.SelectedIndex = 0;
            };

            Cursor = Cursors.WaitCursor;
            counterList.Items.Clear();
            instanceComboBox.Items.Clear();

            worker.RunWorkerAsync(categoryComboBox.SelectedItem);
        }

        private void LoadPerformanceCounters()
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            //
            // Enumerates the counters on a background thread
            //
            worker.DoWork += (sender, e) =>
            {
                try
                {
                    object[] args = e.Argument as object[];
                    string categoryName = args[0] as string;
                    string instanceName = args[1] as string;

                    var category = new PerformanceCounterCategory(categoryName);
                    var counters = (instanceName == "<unnamed>" ? category.GetCounters() : category.GetCounters(instanceName));

                    foreach (var item in counters.OrderBy(c => c.CounterName))
                    {
                        worker.ReportProgress(0, new PerformanceCounterListItem()
                        {
                            Text = item.CounterName,
                            Help = item.CounterHelp
                        });
                    }
                }
                catch {}
            };

            //
            // Adds counters to list
            //
            worker.ProgressChanged += (sender, e) =>
            {
                counterList.Items.Add(e.UserState);
            };

            //
            // Cleans up UI
            //
            worker.RunWorkerCompleted += (sender, e) =>
            {
                Cursor = Cursors.Default;
                if (counterList.Items.Count > 0)
                    counterList.SelectedIndex = 0;
            };

            Cursor = Cursors.WaitCursor;
            counterList.Items.Clear();

            worker.RunWorkerAsync(new object[] { categoryComboBox.SelectedItem, instanceComboBox.SelectedItem });
        }
    }
}