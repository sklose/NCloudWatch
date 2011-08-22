using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace NCloudWatch.Gui
{
    public partial class CreateMetricForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMetricForm"/> class.
        /// </summary>
        public CreateMetricForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the CreateMetricForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CreateMetricForm_Load(object sender, EventArgs e)
        {
            var converter = TypeDescriptor.GetConverter(typeof(MetricUnit));
            var values = from item in Enum.GetValues(typeof(MetricUnit)).OfType<MetricUnit>()
                         orderby converter.ConvertToString(item) ascending
                         select converter.ConvertToString(item);

            unitComboBox.Items.AddRange(values.ToArray());
            unitComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets the report interval.
        /// </summary>
        /// <value>The report interval.</value>
        public TimeSpan ReportInterval
        {
            get
            {
                return new TimeSpan(intervalDateTimePicker.Value.Hour, intervalDateTimePicker.Value.Minute, intervalDateTimePicker.Value.Second);
            }
        }

        /// <summary>
        /// Gets the name of the metric.
        /// </summary>
        /// <value>The name of the metric.</value>
        public string MetricName
        {
            get
            {
                return metricNameTextBox.Text;
            }
        }

        /// <summary>
        /// Gets the unit.
        /// </summary>
        /// <value>The unit.</value>
        public MetricUnit Unit
        {
            get
            {
                var converter = TypeDescriptor.GetConverter(typeof(MetricUnit));
                return (MetricUnit)converter.ConvertTo(unitComboBox.SelectedItem, typeof(MetricUnit));
            }
        }
    }
}