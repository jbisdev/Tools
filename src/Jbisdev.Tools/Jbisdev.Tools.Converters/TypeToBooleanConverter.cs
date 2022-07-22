using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class TypeToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Comparison type
        /// </summary>
        public Type ParameterType { get; set; }

        /// <summary>
        /// Determine if an object is of one specific type
        /// </summary>
        /// <param name="value">Any type object</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True if value is of type of parametertype, false otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || ParameterType == null)
            {
                return false;
            }
            Type type = ParameterType;
            Type type1 = value.GetType();
            if (typeof(Type).IsAssignableFrom(type1))
            {
                type1 = (Type)value;
            }
            return type.IsAssignableFrom(type1);
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}