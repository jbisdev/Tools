using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Jbisdev.Tools.Attributes
{
    /// <summary>
    /// Attribute for localization.
    /// <example>
    /// [LocalizableDescription(@"Key", typeof(Resource))]
    /// </example>
    /// </summary>
    ///
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public class LocalizableDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the LocalizableDescriptionAttribute class.
        /// <para>LocalizableDescriptionAttribute class enable to get the description of the element and to have the possibility to translate the description</para>
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="resourcesType">Type of the resources.</param>
        public LocalizableDescriptionAttribute(string description, Type resourcesType)
            : base(description)
        {
            _resourcesType = resourcesType;
        }

        /// <summary>
        /// Get the string value from the resources.
        /// </summary>
        /// <returns>The description stored in this attribute.</returns>
        public override string Description
        {
            get
            {
                if (_isLocalized)
                    return DescriptionValue;

                var culture = CultureInfo.DefaultThreadCurrentCulture;

                _isLocalized = true;

                if (_resourcesType.InvokeMember(
                        @"ResourceManager",
                        BindingFlags.GetProperty | BindingFlags.Static |
                        BindingFlags.Public | BindingFlags.NonPublic,
                        null,
                        null,
                        Array.Empty<object>()) is ResourceManager resMan)
                    DescriptionValue = resMan.GetString(DescriptionValue, culture);

                return DescriptionValue;
            }
        }

        private readonly Type _resourcesType;
        private bool _isLocalized;
    }
}