using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Resources;

namespace Jbisdev.Tools.Helpers.Localization.Tests
{
    [TestClass()]
    public class LocalizationHelperTests
    {
        public Assembly ThisAssembly => Assembly.GetAssembly(this.GetType());

        [TestMethod("ExistCacheResourceManager : When there is the resource manager in the cache, should return true")]
        public void ExistCacheResourceManaagerManagerExist()
        {
            var resourceManagerName = "ResourcesTests";
            var resourceManager = new ResourceManager(resourceManagerName, ThisAssembly);
            var localizationHelper = new LocalizationHelper(new() { { resourceManagerName, resourceManager } });

            var result = localizationHelper.ExistCacheResourceManager(resourceManager);

            Assert.IsTrue(result);
        }

        [TestMethod("ExistCacheResourceManager : When there is not the resource manager in the cache, should return false")]
        public void ExistCacheResourceManagerManagerDoesNotExist()
        {
            var resourceManagerName = "Resources.Tests";
            var resourceManager = new ResourceManager(resourceManagerName, ThisAssembly);
            var localizationHelper = new LocalizationHelper();

            var result = localizationHelper.ExistCacheResourceManager(resourceManager);

            Assert.IsFalse(result);
        }

        [TestMethod("AddResourceManager : When resourceManager named Tests, " +
            "should entry with key Tests and the resourceManager in the cache")]
        public void AddResourceManager()
        {
            var resourceManagerName = "Tests";
            var cache = new Dictionary<string, ResourceManager>();
            var assembly = ThisAssembly;
            var resourceManager = new ResourceManager(resourceManagerName, assembly);
            var localizationHelper = new LocalizationHelper(cache);
            var expected = new Dictionary<string, ResourceManager>
            {
                {resourceManagerName,resourceManager}
            };

            localizationHelper.AddResourceManager(resourceManager);

            CollectionAssert.AreEqual(expected, cache);
        }

        [TestMethod("this[string key] : When key is NotInGoodFormat, should throws argument exception")]
        [ExpectedException(typeof(ArgumentException))]
        public void ThisStringKeyNotGoodFormatKey()
        {
            var key = "NotInGoodFormat";
            var localizationHelper = new LocalizationHelper();

            _ = localizationHelper[key];

            Assert.Fail();
        }

        [TestMethod("this[string key] : When key is Tests and there is no resource manager named Tests in cache" +
            ", should return null")]
        public void ThisStringKeyNotContainsResource()
        {
            var key = "Resources.Tests";
            var localizationHelper = new LocalizationHelper();

            var result = localizationHelper[key];

            Assert.IsNull(result);
        }

        //[TestMethod("this[string key] : When key is Tests and there is resource manager named Tests in cache" +
        //    ", should return the resourceManagerName with extension")]
        //public void ThisStringKeyContainsResource()
        //{
        //    CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
        //    var resourceManagerName = "Tests";
        //    var baseName = "Resources." + resourceManagerName;
        //    var resourceManager = new ResourceManager(baseName, ThisAssembly);

        //    var localizationHelper = new LocalizationHelper();
        //    localizationHelper.AddResourceManager(resourceManager);

        //    var result = localizationHelper[baseName];

        //    Assert.AreEqual(resourceManagerName, result);
        //}
    }
}