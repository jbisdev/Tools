using Jbisdev.Tools.ConvertersTests.Dummys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class ToCloneConverterTests
    {
        [TestMethod("Convert : When value is not cloneable, should return value")]
        public void ConvertNotCloneable()
        {
            var value = new Class();
            var expected = new Class();
            var converter = new ToCloneConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value is cloneable, should return his clone")]
        public void ConvertCloneable()
        {
            var value = new CloneableClass() { Property = "" };
            var expected = value.Clone();
            var converter = new ToCloneConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }
    }
}