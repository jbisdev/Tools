using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    [ValueConversion(typeof(Enum), typeof(Visibility))]
    public class EnumToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Obtains visibility in terms of an enum field is in a list of enum field
        /// </summary>
        /// <param name="value">Enum field</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">string with all enum fields available separated by |</param>
        /// <param name="culture"></param>
        /// <example>
        /// if value is Values.value1 and parameter is value5 convert will return collapsed
        /// </example>
        /// <example>
        /// if value is Values.value1 and parameter is value1 convert will return true
        /// </example>
        /// /// <example>
        /// if value is Values.value1 and parameter is value1|value5 convert will return true
        /// </example>
        /// <returns>Visible if value is in parameter, collapsed otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null || (value is not Enum))
                return Visibility.Collapsed;

            var currentState = value.ToString();
            var stateStrings = parameter.ToString();
            return stateStrings.Split('|')
                .Any(state => currentState.Equals(state))
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}