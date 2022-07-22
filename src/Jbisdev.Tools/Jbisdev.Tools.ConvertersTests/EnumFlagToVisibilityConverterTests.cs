using Jbisdev.Tools.Converters.Tests.Dummys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class EnumFlagToVisibilityConverterTests
    {
        [TestMethod("Convert : When value is not enum, should return Unset")]
        public void ConvertValueIsNotEnum()
        {
            var value = "";
            var parameter = FlagValues.value1;
            var expected = DependencyProperty.UnsetValue;
            var converter = new EnumFlagToVisibilityConverter();

            var result = converter.Convert(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When parameter is not enum, should return Unset")]
        public void ConvertParameterIsNotEnum()
        {
            var parameter = "";
            var value = FlagValues.value1;
            var expected = DependencyProperty.UnsetValue;
            var converter = new EnumFlagToVisibilityConverter();

            var result = converter.Convert(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value has not parameter, should return collapsed")]
        public void ConvertValueHasNotParameter()
        {
            var parameter = FlagValues.value3;
            var value = FlagValues.value5;
            var expected = Visibility.Collapsed;
            var converter = new EnumFlagToVisibilityConverter();

            var result = converter.Convert(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value has parameter, should return Visible")]
        public void ConvertValueHasParameter()
        {
            var parameter = FlagValues.value1;
            var value = FlagValues.value5;
            var expected = Visibility.Visible;
            var converter = new EnumFlagToVisibilityConverter();

            var result = converter.Convert(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }
    }
}