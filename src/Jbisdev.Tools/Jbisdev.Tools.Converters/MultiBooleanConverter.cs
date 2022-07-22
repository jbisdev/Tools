using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class MultiBooleanConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert several booleans to one boolean
        /// </summary>
        /// <param name="values">Booleans array</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True if all values are true, false otherwise</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var IsVisible = values.All(ttt => ttt != DependencyProperty.UnsetValue && System.Convert.ToBoolean(ttt));

            return IsVisible;
        }

        [ExcludeFromCodeCoverage]
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}