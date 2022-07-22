using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    public class EnumFlagConverter : IValueConverter
    {
        /// <summary>
        /// Determine if an enum field is specified in enum instance
        /// </summary>
        /// <param name="value">Enum instance</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Enum field</param>
        /// <param name="culture"></param>
        /// <returns>True if parameter is specified in value, false otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var theEnum = value as Enum;
            return theEnum.HasFlag(parameter as Enum);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var theEnum = parameter as Enum;
            return theEnum;
        }
    }

    public class EnumFlagMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// Determine if an enum field is specified in enum instance
        /// </summary>
        /// <param name="values">objects array with firstly enum instance and after enum field</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True if value 2 is specified in value 1, false otherwise</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(v => v == DependencyProperty.UnsetValue))
                return false;
            var theEnum = values[0] as Enum;
            var value = values[1] as Enum;
            return theEnum.HasFlag(value);
        }

        [ExcludeFromCodeCoverage]
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Obtains visibility in terms of an enum field is specified in enum instance
    /// </summary>
    /// <param name="value">Enum instance</param>
    /// <param name="targetType"></param>
    /// <param name="parameter">Enum field</param>
    /// <param name="culture"></param>
    /// <returns>True if parameter is specified in value, false otherwise</returns>
    public class EnumFlagToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not Enum theEnum || parameter is not Enum otherEnum)
                return DependencyProperty.UnsetValue;
            return theEnum.HasFlag(otherEnum) ? Visibility.Visible : Visibility.Collapsed;
        }

        [ExcludeFromCodeCoverage]
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class EnumFlagToVisibilityMultiConverter : IMultiValueConverter
    {
        private readonly EnumFlagMultiConverter flagMultiConverter = new();

        /// <summary>
        /// Obtains visibility in terms of an enum field is specified in enum instance
        /// </summary>
        /// <param name="values">objects array with firstly enum instance and after enum field</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>Visible if the value field is specified in flag enum value, collapsed otherwise</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var isVisible = System.Convert.ToBoolean(flagMultiConverter.Convert(values, targetType, parameter, culture));
            return isVisible ? Visibility.Visible : Visibility.Collapsed;
        }

        [ExcludeFromCodeCoverage]
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Converter to determine if enum fields are specified in enum instance of same type
    /// </summary>
    /// <typeparam name="T">Type of enum</typeparam>
    public class EnumFlagConverter<T> : DependencyObject, IValueConverter
        where T : Enum
    {
        public T EnumProperty
        {
            get { return (T)GetValue(EnumPropertyProperty); }
            set { SetValue(EnumPropertyProperty, value); }
        }

        public static readonly DependencyProperty EnumPropertyProperty =
            DependencyProperty.Register("EnumProperty", typeof(T), typeof(EnumFlagConverter<T>));

        /// <summary>
        /// Determine if an enum field is specified in enum instance
        /// </summary>
        /// <param name="value">Enum instance</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Enum field</param>
        /// <param name="culture"></param>
        /// <returns>True if value and parameter are of enumproperty type and parameter is specified in value, false otherwise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not T theEnum || parameter is not T parameterEnum)
                return false;
            EnumProperty = theEnum;
            return EnumProperty.HasFlag(parameterEnum);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var include = (bool)value;
            if (include)
                EnumProperty = EnumProperty.Include((T)parameter);
            else
                EnumProperty = EnumProperty.Remove((T)parameter);

            return EnumProperty;
        }
    }

    public static class SomeEnumHelperMethodsThatMakeDoingWhatYouWantEasier
    {
        public static T IncludeAll<T>(this Enum value)
        {
            Type type = value.GetType();
            object result = value;
            string[] names = Enum.GetNames(type);
            foreach (var name in names)
            {
                ((Enum)result).Include(Enum.Parse(type, name));
            }

            return (T)result;
        }

        /// <summary>
        /// Includes an enumerated type and returns the new value
        /// </summary>
        public static T Include<T>(this Enum value, T append)
        {
            Type type = value.GetType();

            //determine the values
            object result = value;
            var parsed = new _Value(append, type);
            if (parsed.Signed is long @int)
            {
                result = Convert.ToInt64(value) | @int;
            }
            else if (parsed.Unsigned is ulong int1)
            {
                result = Convert.ToUInt64(value) | int1;
            }

            //return the final value
            return (T)Enum.Parse(type, result.ToString());
        }

        /// <summary>
        /// Check to see if a flags enumeration has a specific flag set.
        /// </summary>
        /// <param name="variable">Flags enumeration to check</param>
        /// <param name="value">Flag to check for</param>
        /// <returns></returns>
        public static bool HasFlag(this Enum variable, Enum value)
        {
            if (variable == null)
                return false;

            if (value == null)
                throw new ArgumentNullException("value");

            // Not as good as the .NET 4 version of this function,
            // but should be good enough
            if (!Enum.IsDefined(variable.GetType(), value))
            {
                throw new ArgumentException(string.Format(
                    "Enumeration type mismatch.  The flag is of type '{0}', " +
                    "was expecting '{1}'.", value.GetType(),
                    variable.GetType()));
            }

            ulong num = Convert.ToUInt64(value);
            return ((Convert.ToUInt64(variable) & num) == num);
        }

        /// <summary>
        /// Removes an enumerated type and returns the new value
        /// </summary>
        public static T Remove<T>(this Enum value, T remove)
        {
            Type type = value.GetType();

            //determine the values
            object result = value;
            var parsed = new _Value(remove, type);
            if (parsed.Signed is long @int)
            {
                result = Convert.ToInt64(value) & ~@int;
            }
            else if (parsed.Unsigned is ulong int1)
            {
                result = Convert.ToUInt64(value) & ~int1;
            }

            //return the final value
            return (T)Enum.Parse(type, result.ToString());
        }

        //class to simplfy narrowing values between
        //a ulong and long since either value should
        //cover any lesser value
        private class _Value
        {
            //cached comparisons for tye to use
            private static readonly Type _UInt32 = typeof(long);

            private static readonly Type _UInt64 = typeof(ulong);

            public readonly long? Signed;
            public readonly ulong? Unsigned;

            public _Value(object value, Type type)
            {
                //make sure it is even an enum to work with
                if (!type.IsEnum)
                {
                    throw new ArgumentException(
                        "Value provided is not an enumerated type!");
                }

                //then check for the enumerated value
                Type compare = Enum.GetUnderlyingType(type);

                //if this is an unsigned long then the only
                //value that can hold it would be a ulong
                if (compare.Equals(_UInt32) || compare.Equals(_UInt64))
                {
                    Unsigned = Convert.ToUInt64(value);
                }
                //otherwise, a long should cover anything else
                else
                {
                    Signed = Convert.ToInt64(value);
                }
            }
        }
    }
}