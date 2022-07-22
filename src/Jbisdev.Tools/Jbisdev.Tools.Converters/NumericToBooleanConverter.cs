using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    /// <summary>
    /// Converter to convert integer values to booleans
    /// </summary>
    public class NumericToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Convert an integer value to a boolean
        /// </summary>
        /// <param name="value">Integer value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>False if value is 0, true if value grreater than 0</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not int numericValue)
            {
                return null;
            }
            return System.Convert.ToBoolean(numericValue);
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}