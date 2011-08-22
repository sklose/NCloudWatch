using System;
using System.IO;
using System.Runtime.Serialization;

namespace NCloudWatch
{
    [DataContract(Name = "settings")]
    public class CloudWatchServiceConfiguration
    {
        private static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NCloudWatch", "settings.xml");

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudWatchServiceConfiguration"/> class.
        /// </summary>
        public CloudWatchServiceConfiguration()
        {
            Metrics = new MetricList();
        }

        /// <summary>
        /// Gets or sets the AWS access key id.
        /// </summary>
        /// <value>The AWS access key id.</value>
        [DataMember(Name = "awsAccessKeyID")]
        public string AwsAccessKeyId { get; set; }

        /// <summary>
        /// Gets or sets the AWS secret access key.
        /// </summary>
        /// <value>The AWS secret access key.</value>
        [DataMember(Name = "awsSecretAccessKey")]
        public string AwsSecretAccessKey { get; set; }

        /// <summary>
        /// Gets or sets the metrics.
        /// </summary>
        /// <value>The metrics.</value>
        [DataMember(Name = "metrics")]
        public MetricList Metrics { get; set; }

        /// <summary>
        /// Loads the configuration from the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The configuration.</returns>
        public static CloudWatchServiceConfiguration Load(string path)
        {
            if (!File.Exists(path))
            {
                return new CloudWatchServiceConfiguration();
            }
            else
            {
                var serializer = new DataContractSerializer(typeof(CloudWatchServiceConfiguration));
                using (var stream = File.OpenRead(path))
                {
                    return serializer.ReadObject(stream) as CloudWatchServiceConfiguration;
                }
            }
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        /// <returns></returns>
        public static CloudWatchServiceConfiguration Load()
        {
            return Load(path);
        }

        /// <summary>
        /// Saves this configuration to the specified <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The path.</param>
        public void Save(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }

            var serializer = new DataContractSerializer(typeof(CloudWatchServiceConfiguration));
            using (var writer = new System.Xml.XmlTextWriter(path, System.Text.Encoding.UTF8))
            {
                writer.Formatting = System.Xml.Formatting.Indented;                                
                serializer.WriteObject(writer, this);
            }
        }

        /// <summary>
        /// Saves this configuration.
        /// </summary>
        public void Save()
        {
            Save(path);
        }
    }
}