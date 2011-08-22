using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading;

using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using NLog;

namespace NCloudWatch
{
    public class CloudWatchService : IDisposable
    {
        #region Private Fields

        private object awsClientSyncRoot = new object();
        private Logger logger;

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the performance counters.
        /// </summary>
        /// <value>The performance counters.</value>
        private ConcurrentDictionary<PerformanceCounterDescription, PerformanceCounter> PerformanceCounters { get; set; }

        /// <summary>
        /// Gets or sets the Amazon Web Services client for CloudWatch.
        /// </summary>
        /// <value>The AWS client.</value>
        private AmazonCloudWatchClient AwsClient { get; set; }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        private CloudWatchServiceConfiguration Configuration { get; set; }

        /// <summary>
        /// Gets or sets the management service host.
        /// </summary>
        /// <value>The management service host.</value>
        private WebServiceHost ManagementServiceHost { get; set; }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        private string InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the availability zone.
        /// </summary>
        /// <value>The availability zone.</value>
        private string AvailabilityZone { get; set; }

        #endregion

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudWatchService"/> class.
        /// </summary>
        public CloudWatchService()
        {
            PerformanceCounters = new ConcurrentDictionary<PerformanceCounterDescription, PerformanceCounter>();
            ManagementServiceHost = new WebServiceHost(new ManagementService(this), new Uri(ManagementService.LocalEndpointUrl));
            ManagementServiceHost.AddServiceEndpoint(typeof(IManagementService), new WebHttpBinding(), string.Empty);

            var config = new NLog.Config.LoggingConfiguration();
            config.AddTarget("File", new NLog.Targets.FileTarget()
            {
                FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NCloudWatch", "log.txt")                
            });
            config.LoggingRules.Add(new NLog.Config.LoggingRule("*", LogLevel.Info, config.FindTargetByName("File")));
            
            LogManager.Configuration = config;
            logger = LogManager.GetLogger("NCloudWatch");
        }

        #endregion

        #region IDisposable Pattern

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                try
                {
                    logger.Info("Closing Management interface");
                    ManagementServiceHost.Close();
                }
                catch (Exception ex) 
                {
                    logger.Error(ex);
                }

                lock (Configuration)
                {
                    //
                    // Stop all background threads that upload metric data
                    //
                    foreach (var metric in Configuration.Metrics)
                    {
                        logger.Info("Stopping Metric '{0}'", metric.Name);
                        metric.StopEvent.Set();
                    }
                }
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="CloudWatchService"/> is reclaimed by garbage collection.
        /// </summary>
        ~CloudWatchService()
        {
            Dispose(false);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Starts collecting and uploading metrics.
        /// </summary>
        public void Start()
        {
            logger.Info("Starting CloudWatch Service");
            Configuration = CloudWatchServiceConfiguration.Load();
            lock (Configuration)
            {
                logger.Info("Creating AWS Client with AccessKeyID '{0}'", Configuration.AwsAccessKeyId);
                AwsClient = new AmazonCloudWatchClient(Configuration.AwsAccessKeyId, Configuration.AwsSecretAccessKey);
                foreach (var metric in Configuration.Metrics)
                {
                    metric.StopEvent = new ManualResetEvent(false);
                    logger.Info("Registering Metric '{0}'", metric.Name);
                    RegisterMetricForProcessing(metric);
                }
            }

            try
            {
                logger.Info("Opening Mangement interface at {0}", ManagementServiceHost.BaseAddresses[0]);
                ManagementServiceHost.Open();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            try
            {
                logger.Info("Retrieving Instance ID for EC2 instance");
                var client = new System.Net.WebClient();
                InstanceId = client.DownloadString("http://169.254.169.254/2009-04-04/meta-data/instance-id");
                logger.Info("Local Instance ID is '{0}'", InstanceId);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            try
            {
                logger.Info("Retrieving Availability Zone for EC2 instance");
                var client = new System.Net.WebClient();
                AvailabilityZone = client.DownloadString("http://169.254.169.254/2009-04-04/meta-data/placement/availability-zone");
                logger.Info("Availability Zone is '{0}'", AvailabilityZone);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        /// <summary>
        /// Stops collecting and uploading metrics.
        /// </summary>
        public void Stop()
        {
            Dispose();
        }

        /// <summary>
        /// Sets the Amazon Web Services credentials.
        /// </summary>
        /// <param name="accessKeyId">The access key id.</param>
        /// <param name="secretAccessKey">The secret access key.</param>
        public void SetAwsCredentials(string accessKeyId, string secretAccessKey)
        {
            logger.Info("Setting new AWS credentials with AccessKeyID '{0}'", accessKeyId);

            //
            // Update configuration
            //
            lock (Configuration)
            {
                Configuration.AwsAccessKeyId = accessKeyId;
                Configuration.AwsSecretAccessKey = secretAccessKey;
                Configuration.Save();
            }

            //
            // Replace AWS client
            //
            lock (awsClientSyncRoot)
            {
                AwsClient = new AmazonCloudWatchClient(accessKeyId, secretAccessKey);
            }
        }

        /// <summary>
        /// Adds the specified <paramref name="metric"/>.
        /// </summary>
        /// <param name="metric">The metric.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metric"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">A <see cref="Metric"/> with the same name already exists.</exception>
        public void AddMetric(Metric metric)
        {
            if (metric == null)
            {
                logger.Error("Tried to add NULL Metric");
                throw new ArgumentNullException("metric");
            }

            lock (Configuration)
            {
                if (Configuration.Metrics.Any(m => m.Name == metric.Name))
                {
                    logger.Error("Tried to add Metric '{0}' which already exists", metric.Name);
                    throw new InvalidOperationException(string.Format("Metric '{0}' already exists", metric.Name));
                }

                logger.Info("Adding Metric '{0}'", metric.Name);
                Configuration.Metrics.Add(metric);
                Configuration.Save();

                metric.StopEvent = new ManualResetEvent(false);
                RegisterMetricForProcessing(metric);
            }
        }

        /// <summary>
        /// Gets all metrics.
        /// </summary>
        /// <returns>The metrics.</returns>
        public Metric[] GetMetrics()
        {
            lock (Configuration)
            {
                logger.Info("Retrieving list of Metrics");
                return Configuration.Metrics.ToArray();
            }
        }

        /// <summary>
        /// Removes the metric with the specified <paramref name="metricName"/>.
        /// </summary>
        /// <param name="metricName">Name of the metric.</param>
        public void RemoveMetric(string metricName)
        {
            lock (Configuration)
            {
                var metric = Configuration.Metrics.FirstOrDefault(m => m.Name == metricName);
                if (metric != null)
                {
                    logger.Info("Remvoing Metric '{0}'", metric.Name);
                    metric.StopEvent.Set();
                    Configuration.Metrics.Remove(metric);
                    Configuration.Save();
                }
                else
                {
                    logger.Error("Unable to remove Metric '{0}', it doesn't exist", metricName);
                }
            }
        }

        #endregion

        #region Private Methods

        private void RegisterMetricForProcessing(Metric metric)
        {
            ThreadPool.RegisterWaitForSingleObject(metric.StopEvent, ReportMetric, metric, metric.ReportInterval, true);
        }

        /// <summary>
        /// Reports the metric that is defined by <paramref name="state"/> to the Amazon CloudWatch service.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="timeout">if set to <c>true</c> a timeout occured.</param>
        private void ReportMetric(object state, bool timeout)
        {
            var metric = state as Metric;
            if (timeout)
            {
                //
                // Retrieve current value of metric
                //
                MetricDatum datum = null;
                if (metric is PerformanceCounterMetric)
                {
                    var description = ((PerformanceCounterMetric)metric).PerformanceCounter;
                    if (!PerformanceCounters.ContainsKey(description))
                    {
                        LoadPerformanceCounter(description);
                    }

                    var unitConverter = TypeDescriptor.GetConverter(typeof(MetricUnit));

                    var counter = PerformanceCounters[description];
                    datum = new MetricDatum().WithMetricName(metric.Name)
                                             .WithTimestamp(DateTime.Now)
                                             .WithUnit((string)unitConverter.ConvertTo(metric.Unit, typeof(string)))
                                             .WithValue(counter.NextValue());
                }

                //
                // Mark datum with Instance ID and Availability Zone
                //
                if (datum != null)
                {
                    if (!string.IsNullOrEmpty(InstanceId))
                    {
                        datum.Dimensions.Add(
                            new Dimension().WithName("InstanceId").WithValue(InstanceId)
                        );
                    }

                    if (!string.IsNullOrEmpty(AvailabilityZone))
                    {
                        datum.Dimensions.Add(
                            new Dimension().WithName("Region").WithValue(AvailabilityZone)
                        );
                    }
                }

                //
                // Report value to CloudWatch service
                //
                if (datum != null)
                {
                    IList<MetricDatum> data = new List<MetricDatum>();
                    data.Add(datum);
                    lock (awsClientSyncRoot)
                    {
                        try
                        {
                            logger.Info("Reporting Metric '{0}' to CloudWatch", datum.MetricName);
                            AwsClient.PutMetricData(new PutMetricDataRequest()
                                .WithMetricData(data)
                                .WithNamespace("System/Windows")
                            );
                        }
                        catch (Exception ex) 
                        {
                            logger.Error(ex);
                        }
                    }
                }

                //
                // Register for next report interval
                //
                RegisterMetricForProcessing(metric);
            }
        }

        private void LoadPerformanceCounter(PerformanceCounterDescription performanceCounter)
        {
            var counter = new PerformanceCounter();
            counter.CategoryName = performanceCounter.Category;
            counter.CounterName = performanceCounter.Name;
            counter.InstanceName = performanceCounter.InstanceName;

            PerformanceCounters.TryAdd(performanceCounter, counter);
        }

        #endregion
    }
}