using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Determine if an enum field is in a list of several enums
        /// </summary>
        /// <param name="value">Enum field</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">String with all enum fields separated by | or &</param>
        /// <param name="culture"></param>
        /// <returns>
        /// True if value is specified in parameter, false otherwise
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            var checkValue = value.ToString();
            var targetValue = parameter.ToString();
            if (targetValue.Contains("["))
                targetValue = targetValue.Substring(0, targetValue.LastIndexOf("["));
            if (targetValue.Contains("|"))
                return targetValue.Split('|').Any(state => checkValue.Equals(state));
            else if (targetValue.Contains("&"))
                return targetValue.Split('&').All(state => checkValue.Equals(state));

            return checkValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return null;

            var useValue = System.Convert.ToBoolean(value);
            var targetValue = parameter.ToString();

            if (useValue)
            {
                if (targetValue.Contains("["))
                    targetValue = targetValue.Substring(0, targetValue.LastIndexOf("["));
                return Enum.Parse(targetType, targetValue);
            }
            if (targetValue.Contains("["))
            {
                targetValue = targetValue.Substring(targetValue.LastIndexOf("[")).Replace("[", "").Replace("]", "");
                return Enum.Parse(targetType, targetValue);
            }

            return null;
        }
    }
}