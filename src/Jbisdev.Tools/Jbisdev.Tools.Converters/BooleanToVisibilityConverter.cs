using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    /// <summary>
    /// Converts Boolean Values to Control.Visibility values
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// <para>Set to true if you want to show control when boolean value is true</para>
        /// <para>Set to false if you want to hide/collapse control when value is true</para>
        /// </summary>
        private bool triggerValue = false;

        /// <summary>
        /// <para>Set to true if you want to show control when boolean value is true</para>
        /// <para>Set to false if you want to hide/collapse control when value is true</para>
        /// </summary>
        public bool TriggerValue
        {
            get { return triggerValue; }
            set { triggerValue = value; }
        }

        /// <summary>
        /// <para>Set to true if you just want to hide the control</para>
        /// <para>Set to false if you want to collapse the control</para>
        /// </summary>
        private bool isHidden;

        /// <summary>
        /// <para>Set to true if you just want to hide the control</para>
        /// <para>Set to false if you want to collapse the control</para>
        /// </summary>
        public bool IsHidden
        {
            get { return isHidden; }
            set { isHidden = value; }
        }

        private object GetVisibility(object value)
        {
            if (value is not bool)
                return DependencyProperty.UnsetValue;
            var objValue = (bool)value;
            if ((objValue && TriggerValue && IsHidden) || (!objValue && !TriggerValue && IsHidden))
            {
                return Visibility.Hidden;
            }
            if ((objValue && TriggerValue && !IsHidden) || (!objValue && !TriggerValue && !IsHidden))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        /// <summary>
        /// Obtains visibility in terms of a boolean value
        /// </summary>
        /// <param name="values">Booleans value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Hidden if value is true and trigger value is true and hidden is true
        /// or if value is false and trigger value is false and hidden is true,
        /// Collapsed if value is true and trigger value is true and hidden is false
        /// or if value is false and trigger value is false and hidden is false, visible otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GetVisibility(value);
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiBooleanToVisibilityConverter : IMultiValueConverter
    {
        /// <summary>
        /// <para>Set to true if you want to show control when boolean value is true</para>
        /// <para>Set to false if you want to hide/collapse control when value is true</para>
        /// </summary>
        private bool triggerValue = false;

        /// <summary>
        /// <para>Set to true if you want to show control when boolean value is true</para>
        /// <para>Set to false if you want to hide/collapse control when value is true</para>
        /// </summary>
        public bool TriggerValue
        {
            get { return triggerValue; }
            set { triggerValue = value; }
        }

        /// <summary>
        /// <para>Set to true if you just want to hide the control</para>
        /// <para>Set to false if you want to collapse the control</para>
        /// </summary>
        private bool isHidden;

        /// <summary>
        /// <para>Set to true if you just want to hide the control</para>
        /// <para>Set to false if you want to collapse the control</para>
        /// </summary>
        public bool IsHidden
        {
            get { return isHidden; }
            set { isHidden = value; }
        }

        private object GetVisibility(object[] values)
        {
            if (values == null || values.Any(v => v is not bool))
                return DependencyProperty.UnsetValue;
            var objValue = values.All(v => (bool)v);
            if ((objValue && TriggerValue && IsHidden) || (!objValue && !TriggerValue && IsHidden))
            {
                return Visibility.Hidden;
            }
            if ((objValue && TriggerValue && !IsHidden) || (!objValue && !TriggerValue && !IsHidden))
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        /// <summary>
        /// Obtains visibility in terms of several boolean values
        /// </summary>
        /// <param name="values">Booleans array</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Hidden if values are all true and trigger value is true and  hidden is true
        /// or if some values are false and trigger value is false and hidden is true,
        /// Collapsed if values are all true and trigger value is true and hidden is false
        /// or if some values are false and trigger value is false and hidden is false, visible otherwise</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return GetVisibility(values);
        }

        [ExcludeFromCodeCoverage]
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}