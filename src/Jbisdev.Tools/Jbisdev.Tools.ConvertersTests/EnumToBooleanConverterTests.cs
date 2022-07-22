using Jbisdev.Tools.Converters.Tests.Dummys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class EnumToBooleanConverterTests
    {
        [DataTestMethod()]
        [DataRow(Values.value2, "value1|value2|value4",
            DisplayName = "Convert : When value is value2 and parameter is value1|value2|value4, should return true")]
        [DataRow(Values.value2, "value2",
            DisplayName = "Convert : When value is value2 and parameter is value2, should return true")]
        [DataRow(Values.value2, "value2&value2&value2",
            DisplayName = "Convert : When value is value2 and parameter is value2&value2&value2, should return true")]
        public void ConvertReturnTrue(Values value, string parameter)
        {
            var converter = new EnumToBooleanConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsTrue(result);
        }

        [DataTestMethod()]
        [DataRow(Values.value2, "value1|value3|value4",
            DisplayName = "Convert : When value is value2 and parameter is value1|value3|value4, should return false")]
        [DataRow(Values.value2, "value4",
            DisplayName = "Convert : When value is value2 and parameter is value4, should return false")]
        [DataRow(Values.value4, "value1&value4&value5",
            DisplayName = "Convert : When value is value4 and parameter is value1&value4&value5, should return false")]
        public void ConvertReturnFalse(Values value, string parameter)
        {
            var converter = new EnumToBooleanConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [DataTestMethod()]
        [DataRow(null, "value1|value2|value4",
            DisplayName = "Convert : When value is null and parameter is value1|value2|value4, should return false")]
        [DataRow(Values.value2, null,
            DisplayName = "Convert : When value is value2 and parameter is null, should return false")]
        public void ConvertIncorrectArgs(object value, string parameter)
        {
            var converter = new EnumToBooleanConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }
    }
}