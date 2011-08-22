using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NCloudWatch
{
    [CollectionDataContract(Name = "metrics", ItemName = "metric")]
    public class MetricList : List<Metric>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MetricList"/> class.
        /// </summary>
        public MetricList() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricList"/> class.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public MetricList(int capacity) : base(capacity) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetricList"/> class.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public MetricList(IEnumerable<Metric> collection) : base(collection) { }
    }
}