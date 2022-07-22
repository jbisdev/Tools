using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    /// <summary>
    /// Converter to determine if a value is greater than an other
    /// </summary>
    [ValueConversion(typeof(int), typeof(bool))]
    public class IsGreaterThanConverter : IValueConverter
    {
        /// <summary>
        /// Int value for comparison
        /// </summary>
        public int TriggerValue { get; set; }

        /// <summary>
        /// Determine if a value is greater than triggerValue
        /// </summary>
        /// <param name="value">int,float, decimal or double value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True if value is strictly greater than trigger value, false otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value is not int && value is not double && value is not long && value is not float && value is not decimal)
                return false;

            double.TryParse(value.ToString(), out var number);

            return number > TriggerValue;
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}