using Jbisdev.Tools.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Jbisdev.Tools.Converters
{
    /// <summary>
    /// This class simply takes an enum and uses some reflection to obtain
    /// the friendly name for the enum. Where the friendlier name is
    /// obtained using the LocalizableDescriptionAttribute, which hold the localized
    /// value read from the resource file for the enum
    /// </summary>
    [ValueConversion(typeof(object), typeof(string))]
    public class EnumToDescriptionConverter : IValueConverter
    {
        /// <summary>
        /// Get description of an enum field
        /// </summary>
        /// <param name="value">Enum field</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <example>
        /// In enum named Descriptions : [LocalizableDescription(@"description1"), typeof(Resources.Descriptions)description1,
        /// In ResourceManager named Descriptions : key : description1, value : Description 1 ==>
        /// Convert(Descriptions.description1,...) => Description 1
        /// </example>
        /// <example>
        /// In enum named Descriptions : description1 ==>
        /// Convert(Descriptions.description1,...) => description1
        /// </example>
        /// <returns>Value description if has, his value other wise</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            if (value is not Enum @enum)
                return value;

            var fi = value.GetType().GetField(value.ToString());
            if (fi == null)
                return GetDescriptionFromFlaggedEnum(@enum);
            var attributes =
                (LocalizableDescriptionAttribute[])fi.GetCustomAttributes(typeof(LocalizableDescriptionAttribute), false);

            return ((attributes.Length > 0) &&
                    (!string.IsNullOrEmpty(attributes[0].Description))) ? attributes[0].Description : value.ToString();
        }

        private string GetDescriptionFromFlaggedEnum(Enum @enum)
        {
            const string SEPARATOR = " , ";
            Type type = @enum.GetType();
            var isFlagged = type.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0;
            if (!isFlagged)
                return string.Empty;
            var descriptions = new List<string>();
            string[] names = Enum.GetNames(type);
            foreach (var name in names)
            {
                var value = Enum.Parse(type, name);
                if ((int)value == 0 || !@enum.HasFlag((Enum)value))
                    continue;
                var description = Convert(value, type, null, CultureInfo.InvariantCulture)?.ToString();
                descriptions.Add(description);
            }
            return string.Join(SEPARATOR, descriptions.ToArray());
        }

        /// <summary>
        /// ConvertBack value from binding back to source object
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}