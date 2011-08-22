using System.ServiceModel;

namespace NCloudWatch
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    internal class ManagementService : IManagementService
    {
        public const string LocalEndpointUrl = "http://localhost:9182";

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>
        private CloudWatchService Service
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagementService"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public ManagementService(CloudWatchService service)
        {
            Service = service;
        }

        /// <summary>
        /// Retrieves a list of all metrics.
        /// </summary>
        /// <returns></returns>
        public MetricList GetMetrics()
        {
            return new MetricList(Service.GetMetrics());
        }

        /// <summary>
        /// Removes the metric with the specified <paramref name="metricName"/>.
        /// </summary>
        /// <param name="metricName">Name of the metric.</param>
        public void RemoveMetric(string metricName)
        {
            Service.RemoveMetric(metricName);
        }

        /// <summary>
        /// Adds the specified <paramref name="metric."/>
        /// </summary>
        /// <param name="metric">The metric.</param>
        public void AddMetric(Metric metric)
        {
            Service.AddMetric(metric);
        }

        /// <summary>
        /// Sets the Amazon Web Services credentials.
        /// </summary>
        /// <param name="accessKeyId">The access key id.</param>
        /// <param name="secretAccessKey">The secret access key.</param>
        public void SetAwsCredentials(string accessKeyId, string secretAccessKey)
        {
            Service.SetAwsCredentials(accessKeyId, secretAccessKey);
        }
    }
}