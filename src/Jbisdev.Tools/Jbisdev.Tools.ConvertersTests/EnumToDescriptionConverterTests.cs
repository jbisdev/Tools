using Jbisdev.Tools.Converters.Tests.Dummys;
using Jbisdev.Tools.ConvertersTests.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class EnumToDescriptionConverterTests
    {
        [TestMethod("Convert : When value is null, should return empty string")]
        public void ConvertValueNull()
        {
            object value = null;
            var converter = new EnumToDescriptionConverter();
            var expected = string.Empty;

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value is not an enum, should return value")]
        public void ConvertValueNotEnum()
        {
            var value = new object();
            var converter = new EnumToDescriptionConverter();
            var expected = value;

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value is value1 and his description is defined, should return his description")]
        public void ConvertDefinedDescription()
        {
            var value = Values.value1;
            var converter = new EnumToDescriptionConverter();
            var expected = ResTests.Value1;

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value is value2 and his description is not defined, should return value2")]
        public void ConvertNotDefinedDescription()
        {
            var value = Values.value2;
            var converter = new EnumToDescriptionConverter();
            var expected = "value2";

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value is value1|value3|value5, should return value1 , value3")]
        public void ConvertFlagWhithoutDescription()
        {
            var value = FlagValues.value1 | FlagValues.value3;
            var converter = new EnumToDescriptionConverter();
            var expected = "value1 , value3";

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value is value2|value4, should return their descriptions")]
        public void ConvertFlagWithDescription()
        {
            var value = FlagValues.value2 | FlagValues.value4;
            var converter = new EnumToDescriptionConverter();
            var expected = $"{ResTests.Value2} , {ResTests.Value4}";

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("ConvertBack : Should return value")]
        public void ConvertBack()
        {
            var value = "";
            var expected = "";
            var converter = new EnumToDescriptionConverter();

            var result = converter.ConvertBack(value, null, null, null);

            Assert.AreEqual(expected, result);
        }
    }
}