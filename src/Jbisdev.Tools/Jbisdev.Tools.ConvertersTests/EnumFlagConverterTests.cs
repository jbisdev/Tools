using Jbisdev.Tools.Converters.Tests.Dummys;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class EnumFlagConverterTests
    {
        [TestMethod("Convert : When value is all and parameter is value5, should return true")]
        public void ConvertValueHasParameter()
        {
            var value = FlagValues.all;
            var parameter = FlagValues.value5;
            var converter = new EnumFlagConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is value5 and parameter is value3, should return false")]
        public void ConvertValueHasNotParameter()
        {
            var value = FlagValues.value5;
            var parameter = FlagValues.value3;
            var converter = new EnumFlagConverter();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [TestMethod("ConvertBack : When value is null, should return null")]
        public void ConvertBackValueNull()
        {
            object value = null;
            var converter = new EnumFlagConverter();

            var result = converter.ConvertBack(value, null, null, null);

            Assert.IsNull(result);
        }

        [TestMethod("ConvertBack : When value is value2, should return value2")]
        public void ConvertBack()
        {
            var parameter = Values.value2;
            var converter = new EnumFlagConverter();

            var result = converter.ConvertBack(null, null, parameter, null);

            Assert.AreEqual(parameter, result);
        }

        [TestMethod("Convert : When converter is for Values and value is FlagValues, should return false")]
        public void ConvertValueIsNotGoodEnumType()
        {
            var value = FlagValues.value1;
            var parameter = Values.value2;
            var converter = new EnumFlagConverter<Values>();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When converter is for ValuesRange and parameter is FlagValues, should return false")]
        public void ConvertParameterIsNotGoodEnumType()
        {
            var value = Values.value1;
            var parameter = FlagValues.value2;
            var converter = new EnumFlagConverter<Values>();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value is all and parameter is value5, should return true")]
        public void ConvertValueHasParameterSameEnumType()
        {
            var value = FlagValues.all;
            var parameter = FlagValues.value5;
            var converter = new EnumFlagConverter<FlagValues>();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is value5 and parameter is value3, should return false")]
        public void ConvertValueHasNotParameterSameEnumType()
        {
            var value = FlagValues.value5;
            var parameter = FlagValues.value3;
            var converter = new EnumFlagConverter<FlagValues>();

            var result = (bool)converter.Convert(value, null, parameter, null);

            Assert.IsFalse(result);
        }

        [TestMethod("ConvertBack : When value is true and parameter is value3, should return value3")]
        public void ConvertBackValueTrue()
        {
            var value = true;
            var parameter = FlagValues.value3;
            var expected = FlagValues.value1 | FlagValues.value3;
            var enumProperty = FlagValues.value1;
            var converter = new EnumFlagConverter<FlagValues>() { EnumProperty = enumProperty };

            var result = converter.ConvertBack(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("ConvertBack : When value is false and parameter is value3, should return none")]
        public void ConvertBackValueFalse()
        {
            var value = false;
            var parameter = FlagValues.value3;
            var expected = FlagValues.value1;
            var enumProperty = FlagValues.value3 | FlagValues.value1;
            var converter = new EnumFlagConverter<FlagValues>() { EnumProperty = enumProperty };

            var result = converter.ConvertBack(value, null, parameter, null);

            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class EnumFlagMultiConverterTests
    {
        [TestMethod("Convert : When value 1 is unset and value 2 is value3, should return false")]
        public void ConvertValue1Unset()
        {
            var value1 = DependencyProperty.UnsetValue;
            var value2 = FlagValues.value3;
            var values = new object[] { value1, value2 };
            var converter = new EnumFlagMultiConverter();

            var result = (bool)converter.Convert(values, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value 1 is value5 and value 2 is unset, should return false")]
        public void ConvertValue2Unset()
        {
            var value1 = FlagValues.value5;
            var value2 = DependencyProperty.UnsetValue;
            var values = new object[] { value1, value2 };
            var converter = new EnumFlagMultiConverter();

            var result = (bool)converter.Convert(values, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value 1 is all and value 2 is value3, should return true")]
        public void ConvertValue1HasValue2()
        {
            var value1 = FlagValues.all;
            var value2 = FlagValues.value3;
            var values = new object[] { value1, value2 };
            var converter = new EnumFlagMultiConverter();

            var result = (bool)converter.Convert(values, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value 1 is value5 and value 2 is value4, should return false")]
        public void ConvertValue1HasNotValue2()
        {
            var value1 = FlagValues.value5;
            var value2 = FlagValues.value4;
            var values = new object[] { value1, value2 };
            var converter = new EnumFlagMultiConverter();

            var result = (bool)converter.Convert(values, null, null, null);

            Assert.IsFalse(result);
        }
    }

    [TestClass]
    public class EnumFlagToVisibilityMultiConverterTests
    {
        [TestMethod("Convert : When value 1 is unset and value 2 is value3, should return collapsed")]
        public void ConvertValue1Unset()
        {
            var value1 = DependencyProperty.UnsetValue;
            var value2 = FlagValues.value3;
            var values = new object[] { value1, value2 };
            var expected = Visibility.Collapsed;
            var converter = new EnumFlagToVisibilityMultiConverter();

            var result = converter.Convert(values, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value 1 is value5 and value 2 is unset, should return collapsed")]
        public void ConvertValue2Unset()
        {
            var value1 = FlagValues.value5;
            var value2 = DependencyProperty.UnsetValue;
            var values = new object[] { value1, value2 };
            var expected = Visibility.Collapsed;
            var converter = new EnumFlagToVisibilityMultiConverter();

            var result = converter.Convert(values, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value 1 is all and value 2 is value3, should return visible")]
        public void ConvertValue1HasValue2()
        {
            var value1 = FlagValues.all;
            var value2 = FlagValues.value3;
            var values = new object[] { value1, value2 };
            var expected = Visibility.Visible;
            var converter = new EnumFlagToVisibilityMultiConverter();

            var result = converter.Convert(values, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When value 1 is value5 and value 2 is value4, should return collapsed")]
        public void ConvertValue1HasNotValue2()
        {
            var value1 = FlagValues.value5;
            var value2 = FlagValues.value4;
            var values = new object[] { value1, value2 };
            var expected = Visibility.Collapsed;
            var converter = new EnumFlagToVisibilityMultiConverter();

            var result = converter.Convert(values, null, null, null);

            Assert.AreEqual(expected, result);
        }
    }
}