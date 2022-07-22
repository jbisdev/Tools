using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace Jbisdev.Tools.Helpers.Localization
{
    /// <summary>
    /// This class allow to stock a cache of resource manager and notify all binding properties.
    /// </summary>
    public class LocalizationHelper : INotifyPropertyChanged
    {
        /// <summary>
        /// The cacheResourceManager.
        /// </summary>
        private readonly Dictionary<string, ResourceManager> _cacheResourceManager;

        /// <summary>
        /// Event PropertyChangedEventHandler.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Test if Exist the Resource Manager.
        /// </summary>
        /// <param name="resourceManager">The resourceManager.</param>
        /// <returns>Return true if exist.</returns>
        public bool ExistCacheResourceManager(ResourceManager resourceManager)
        {
            var res = from r in _cacheResourceManager where r.Value == resourceManager select r;
            return res.Any();
        }

        /// <summary>
        /// Initializes a new instance of the LocalizationHelper class.
        /// </summary>
        public LocalizationHelper(Dictionary<string, ResourceManager> cacheResourceManager)
        {
            _cacheResourceManager = cacheResourceManager;
        }

        public LocalizationHelper() : this(new Dictionary<string, ResourceManager>())
        {
        }

        /// <summary>
        /// Add new resource Manager.
        /// </summary>
        /// <param name="resourceManager"></param>
        public void AddResourceManager(ResourceManager resourceManager)
        {
            var splitName = resourceManager.BaseName.Split('.');
            var keyResource = splitName[splitName.Count() - 1];
            _cacheResourceManager.Add(keyResource, resourceManager);
        }

        /// <summary>
        /// Gets Value associated to a key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string this[string key]
        {
            get
            {
                if (!ValidKey(key))
                    throw new ArgumentException(@"Key is not in the valid [ManagerName].[ResourceKey] format");
                var formatKey = GetManagerKey(key);
                if (_cacheResourceManager.ContainsKey(formatKey))
                {
                    var resource = GetResourceKey(key);
                    return _cacheResourceManager[formatKey].GetString(resource, CultureInfo.DefaultThreadCurrentCulture);
                }
                else
                {
                    return null;
                }
            }
        }

        [ExcludeFromCodeCoverage]
        public static void SetDefaultCulture(CultureInfo culture)
        {
            var type = typeof(CultureInfo);
            try
            {
                if (type.GetField("s_userDefaultCulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static) != null)
                    type.InvokeMember("s_userDefaultCulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
                if (type.GetField("s_userDefaultUICulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static) != null)
                    type.InvokeMember("s_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }
            try
            {
                if (type.GetField("m_userDefaultCulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static) != null)
                    type.InvokeMember("m_userDefaultCulture",
                                        BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                        null,
                                        culture,
                                        new object[] { culture });
                if (type.GetField("m_userDefaultUICulture", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static) != null)
                    type.InvokeMember("m_userDefaultUICulture",
                                    BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Static,
                                    null,
                                    culture,
                                    new object[] { culture });
            }
            catch { }
        }

        /// <summary>
        /// Update culture of all resource manager registered.
        /// </summary>
        /// <param name="culture"></param>
        public void UpdateCulture(string culture, bool updateThread = true)
        {
            var newCultureInfo = new CultureInfo(culture);
            if (updateThread)
            {
                Thread.CurrentThread.CurrentCulture = newCultureInfo;
                Thread.CurrentThread.CurrentUICulture = newCultureInfo;
            }
            SetDefaultCulture(newCultureInfo);
            RaisePropertyChanged(string.Empty);
        }

        /// <summary>
        /// RaisePropertyChanged.
        /// </summary>
        /// <param name="propertyName">The propertyName.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            var evt = PropertyChanged;
            if (evt != null)
                evt.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Control if is valid key.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool ValidKey(string input)
        {
            return input.Contains(".");
        }

        /// <summary>
        /// Get manager key.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Return manager value.</returns>
        private string GetManagerKey(string input)
        {
            return input.Split('.')[0];
        }

        /// <summary>
        /// Get resource key.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>Return resource value.</returns>
        private string GetResourceKey(string input)
        {
            var exists = false;
            var resource = "";
            for (int indexResource = 0; indexResource < input.Length; indexResource++)
            {
                if (input[indexResource] == '.')
                {
                    exists = true;
                    indexResource++;
                }
                if (exists)
                    resource += input[indexResource];
            }
            return resource;

            //return input[(input.IndexOf('.') + 1)..];
        }
    }
}