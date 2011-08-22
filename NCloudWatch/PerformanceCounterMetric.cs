using System.Runtime.Serialization;

namespace NCloudWatch
{
    [DataContract(Name = "performanceCounter")]
    public class PerformanceCounterDescription
    {
        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        [DataMember(Name = "category")]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the instance.
        /// </summary>
        /// <value>The name of the instance.</value>
        [DataMember(Name = "instanceName")]
        public string InstanceName { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj)) return false;
            if (!(obj is PerformanceCounterDescription)) return false;

            var other = (PerformanceCounterDescription)obj;
            return (Category == other.Category && Name == other.Name && InstanceName == other.InstanceName);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            int hash = 17 * Name.GetHashCode() + 17 * Category.GetHashCode();
            if (InstanceName != null) hash += 17 * InstanceName.GetHashCode();

            return hash;
        }
    }

    [DataContract(Name = "performanceCounterMetric")]
    public class PerformanceCounterMetric : Metric
    {
        /// <summary>
        /// Gets or sets the performance counter.
        /// </summary>
        /// <value>The performance counter.</value>
        [DataMember(Name = "performanceCounter")]
        public PerformanceCounterDescription PerformanceCounter { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj) &&
                   obj is PerformanceCounterMetric &&
                   ((PerformanceCounterMetric)obj).PerformanceCounter == PerformanceCounter;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return 17 * base.GetHashCode() + 17 * PerformanceCounter.GetHashCode();
        }
    }
}