using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Threading;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    /// <summary>
    /// Converter string-double conversion
    /// </summary>
    public class StringToDoubleConverter : IValueConverter
    {
        /// <summary>
        ///Format a double value to *.***
        /// </summary>
        /// <param name="value">Double value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <example>if value is 1.s, will return null</example>
        /// <example>if value is 1 will return 1,000</example>
        /// <example>if value is -5.4998, will return -5,499</example>
        /// <returns>Value in double format if it's a double, null otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not double @double)
                return null;
            try
            {
                var currentCulture = Thread.CurrentThread.CurrentCulture;
                return System.Convert.ToDouble(@double, currentCulture).ToString("F3", currentCulture);
            }
            catch (Exception)
            {
                return null;
            }
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}