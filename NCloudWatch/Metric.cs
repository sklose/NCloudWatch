using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Threading;

namespace NCloudWatch
{
    [TypeConverter(typeof(MetricUnitTypeConverter))]
    public enum MetricUnit
    {
        BitsPerSecond,
        Gigabytes,
        Count,
        Terabits,
        TerabytesPerSecond,
        MegabitsPerSecond,
        MegabytesPerSecond,
        Microseconds,
        GigabitsPerSecond, 
        Seconds, 
        GigabytesPerSecond, 
        Percent, 
        None, 
        Terabytes, 
        Gigabits, 
        Bytes, 
        KilobitsPerSecond, 
        Megabits, 
        Megabytes, 
        Milliseconds, 
        Bits, 
        Kilobits, 
        KilobytesPerSecond, 
        TerabitsPerSecond, 
        CountPerSecond, 
        Kilobytes, 
        BytesPerSecond
    }

    [DataContract(Name = "metric")]
    [KnownType(typeof(PerformanceCounterMetric))]
    public abstract class Metric
    {
        /// <summary>
        /// Gets or sets the report interval.
        /// </summary>
        /// <value>The report interval.</value>
        [DataMember(Name = "reportInterval")]
        public TimeSpan ReportInterval { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>The unit.</value>
        [DataMember(Name = "unit")]
        public MetricUnit Unit { get; set; }

        /// <summary>
        /// Gets or sets the stop event.
        /// </summary>
        /// <value>The stop event.</value>
        internal ManualResetEvent StopEvent { get; set; }

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
            return (obj is Metric && ((Metric)obj).Name == Name);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}