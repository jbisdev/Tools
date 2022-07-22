using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    /// <summary>
    /// Converter for understand databinding xaml value
    /// </summary>
    public class DatabindingDebugConverter : IValueConverter
    {
        /// <summary>
        /// Get value input
        /// </summary>
        /// <param name="value">The value to debug</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>The value to debug</returns>
        [ExcludeFromCodeCoverage]
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            //Debug.WriteLine(value);
            //Debug.WriteLine(targetType);
            //Debugger.Break();
            return value;
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            //Debugger.Break();
            return value;
        }
    }
}