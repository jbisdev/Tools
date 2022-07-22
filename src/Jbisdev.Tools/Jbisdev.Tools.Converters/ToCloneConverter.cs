using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class ToCloneConverter : IValueConverter
    {
        /// <summary>
        /// Get clone of a value
        /// </summary>
        /// <param name="value">Value to clone</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Clone of value if its type is cloneable, value otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ICloneable cloneable)
                return value;

            return cloneable.Clone();
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}