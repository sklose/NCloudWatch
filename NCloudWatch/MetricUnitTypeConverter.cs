using System;
using System.ComponentModel;

namespace NCloudWatch
{
    internal class MetricUnitTypeConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type"/> that represents the type you want to convert from.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return (sourceType == typeof(MetricUnit) || sourceType == typeof(string));
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return (destinationType == typeof(string) || destinationType == typeof(MetricUnit));
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="destinationType"/> parameter is null. </exception>
        /// <exception cref="T:System.NotSupportedException">The conversion cannot be performed. </exception>
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (!(destinationType == typeof(string) || destinationType == typeof(MetricUnit)))
            {
                throw new ArgumentException("Can only convert to string or MetricUnit.", "destinationType");
            }

            if (!(value.GetType() == typeof(MetricUnit) || value.GetType() == typeof(string)))
            {
                throw new ArgumentException("Can only convert an MetricUnit or string enum.", "value");
            }

            if (destinationType == typeof(string))
            {
                MetricUnit unit = (MetricUnit)value;
                switch (unit)
                {
                    case MetricUnit.BitsPerSecond: return "Bits/Second";
                    case MetricUnit.TerabytesPerSecond: return "Terabytes/Second";
                    case MetricUnit.MegabitsPerSecond: return "Megabits/Second";
                    case MetricUnit.MegabytesPerSecond: return "Megabytes/Second";
                    case MetricUnit.GigabitsPerSecond: return "Gigabits/Second";
                    case MetricUnit.GigabytesPerSecond: return "Gigabytes/Second";
                    case MetricUnit.KilobitsPerSecond: return "Kilobits/Second";
                    case MetricUnit.KilobytesPerSecond: return "Kilobytes/Second";
                    case MetricUnit.TerabitsPerSecond: return "Terabits/Second";
                    case MetricUnit.CountPerSecond: return "Count/Second";
                    case MetricUnit.BytesPerSecond: return "Bytes/Second";
                    default: return unit.ToString();
                }
            }
            else
            {
                return Enum.Parse(typeof(MetricUnit), value.ToString().Replace("/", "Per"));
            }
        }
    }
}