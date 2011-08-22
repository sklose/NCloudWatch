using System.ServiceModel;
using System.ServiceModel.Web;

namespace NCloudWatch
{
    [ServiceContract]
    [ServiceKnownTypeAttribute(typeof(PerformanceCounterMetric))]
    public interface IManagementService
    {
        /// <summary>
        /// Adds the specified <paramref name="metric."/>
        /// </summary>
        /// <param name="metric">The metric.</param>
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "metrics", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        void AddMetric(Metric metric);

        /// <summary>
        /// Retrieves a list of all metrics.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "metrics", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        MetricList GetMetrics();

        /// <summary>
        /// Removes the metric with the specified <paramref name="metricName"/>.
        /// </summary>
        /// <param name="metricName">Name of the metric.</param>
        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "metrics/{metricName}", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        void RemoveMetric(string metricName);

        /// <summary>
        /// Sets the Amazon Web Services credentials.
        /// </summary>
        /// <param name="accessKeyId">The access key id.</param>
        /// <param name="secretAccessKey">The secret access key.</param>
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "awscredentials", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
        void SetAwsCredentials(string accessKeyId, string secretAccessKey);
    }
}