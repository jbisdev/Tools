using System;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class InverseBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Get the inverse of a boolean
        /// </summary>
        /// <param name="value">Boolean value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True if falue is false, false if value is true</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}