using Jbisdev.Tools.ConvertersTests.Dummys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class EqualsConverterTests
    {
        [TestMethod("Convert : When value is same class than parameter, should return true")]
        public void ConvertAreNotEqual()
        {
            var value = new Class { Property = "value" };
            var parameter = new Class { Property = "parameter" };
            var converter = new EqualsConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is null, should return false")]
        public void ConvertValueNull()
        {
            Class value = null;
            var parameter = new Class { Property = "parameter" };
            var converter = new EqualsConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When parameter is null, should return false")]
        public void ConvertParameterNull()
        {
            var value = new Class { Property = "value" };
            Class parameter = null;
            var converter = new EqualsConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value equals parameter, should return true")]
        public void ConvertAreEqual()
        {
            var value = new Class { Property = "value" };
            var parameter = new Class { Property = "value" };
            var converter = new EqualsConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is 5 and parameter is 4, should return false")]
        public void ConvertIntegerValueNotEqualsParameter()
        {
            var value = 5;
            var parameter = 4;
            var converter = new EqualsConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value is 5 and parameter is 5, should return true")]
        public void ConvertIntegerValueEqualsParameter()
        {
            var value = 5;
            var parameter = 5;
            var converter = new EqualsConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsTrue(result);
        }
    }
}