using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class EqualsConverter : IValueConverter
    {
        /// <summary>
        /// Determine if a value equals an other
        /// </summary>
        /// <param name="value">Any object type</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Any other object type</param>
        /// <param name="culture"></param>
        /// <returns>True if value equals parameter, false otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToBoolean(value?.ToString()?.Equals(parameter?.ToString()));
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return parameter;
        }
    }
}