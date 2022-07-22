using Jbisdev.Tools.Converters.Tests.Dummys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class EnumToVisibilityConverterTests
    {
        [DataTestMethod()]
        [DataRow(Values.value2, "value3", Visibility.Collapsed,
            DisplayName = "Convert : When parameter is value3 and value is value2, should return collapsed")]
        [DataRow(Values.value3, "value2|value5|value1", Visibility.Collapsed,
            DisplayName = "Convert : When parameter is value2|value5|value1 and value is value3, should return collapsed")]
        [DataRow(Values.value4, "value4", Visibility.Visible,
            DisplayName = "Convert : When parameter is value4 and value is value4, should return Visible")]
        [DataRow(Values.value1, "value2|value5|value1", Visibility.Visible,
            DisplayName = "Convert : When parameter is value2|value5|value1 and value is value1, should return visible")]
        public void Convert(Values value, string parameter, Visibility expected)
        {
            var converter = new EnumToVisibilityConverter();

            var result = converter.Convert(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow("value2", "value2",
            DisplayName = "Convert : When parameter is value2 and value is string, should return collapsed")]
        [DataRow(null, "value2",
            DisplayName = "Convert : When parameter is value2 and value is null, should return collapsed")]
        [DataRow(Values.value2, null,
            DisplayName = "Convert : When parameter is value2 and value is value2, should return collapsed")]
        public void ConvertIncorrectArgs(object value, string parameter)
        {
            var expected = Visibility.Collapsed;
            var converter = new EnumToVisibilityConverter();

            var result = converter.Convert(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }
    }
}