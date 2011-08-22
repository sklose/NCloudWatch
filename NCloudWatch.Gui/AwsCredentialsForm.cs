using System.Windows.Forms;

namespace NCloudWatch.Gui
{
    public partial class AwsCredentialsForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AwsCredentialsForm"/> class.
        /// </summary>
        public AwsCredentialsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the access key id.
        /// </summary>
        /// <value>The access key id.</value>
        public string AccessKeyId
        {
            get { return accessKeyIdTextBox.Text; }
        }

        /// <summary>
        /// Gets the secret access key.
        /// </summary>
        /// <value>The secret access key.</value>
        public string SecretAccessKey
        {
            get { return secretAccessKeyTextBox.Text; }
        }
    }
}
