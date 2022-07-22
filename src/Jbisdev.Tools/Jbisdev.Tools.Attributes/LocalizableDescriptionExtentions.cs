using System;
using System.ComponentModel;
using System.Linq;

namespace Jbisdev.Tools.Attributes
{
    /// <summary>
    /// Extensions for LocalizableDescriptionAttribute
    /// </summary>
    public static class LocalizableDescriptionExtentions
    {
        /// <summary>
        /// Get the description of an enum field or his value if no description specified
        /// </summary>
        /// <param name="enumObj"></param>
        /// <example>
        /// In enum named Examples : example1. GetDescription(Examples.example1 will return example1
        /// </example>
        /// <example>
        /// In enum named Examples : [LocalizableDescription(@"example1"), typeof(Resources.Examples)example1;
        /// in Examples ResourceManager : Resouce named example with Example 1 value. GetDescription(Examples.example1)
        /// returns Example 1
        /// </example>
        /// <returns>The description of enum field if exists, enum field value otherwise</returns>
        public static string GetDescription(this Enum enumObj)
        {
            var fieldInfo = enumObj.GetType().GetField(enumObj.ToString());

            var attribArray = fieldInfo.GetCustomAttributes(false);

            if (attribArray.Length == 0)
            {
                return enumObj.ToString();
            }
            var attrib = attribArray.FirstOrDefault(a => a is DescriptionAttribute) as DescriptionAttribute;
            return attrib?.Description ?? enumObj.ToString();
        }
    }
}