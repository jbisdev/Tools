using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class NullToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Determine if a value is null
        /// </summary>
        /// <param name="value">Any object type</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True if value is null or if value is empty string, false otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is string
                ? string.IsNullOrEmpty(value.ToString())
                : value is null;
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}