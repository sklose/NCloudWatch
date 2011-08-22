using System.ServiceProcess;

namespace NCloudWatch.Service
{
    public partial class Service : ServiceBase
    {
        private CloudWatchService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service"/> class.
        /// </summary>
        public Service()
        {
            InitializeComponent();
            service = new CloudWatchService();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Start command is sent to the service by the Service Control Manager (SCM) or when the operating system starts (for a service that starts automatically). Specifies actions to take when the service starts.
        /// </summary>
        /// <param name="args">Data passed by the start command.</param>
        protected override void OnStart(string[] args)
        {
            service.Start();
        }

        /// <summary>
        /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
        /// </summary>
        protected override void OnStop()
        {
            service.Stop();
        }
    }
}