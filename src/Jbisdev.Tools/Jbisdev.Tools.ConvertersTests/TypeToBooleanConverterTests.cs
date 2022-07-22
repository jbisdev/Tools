using Jbisdev.Tools.ConvertersTests.Dummys;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class TypeToBooleanConverterTests
    {
        [TestMethod("Convert : When value is not of the same type than ParameterType, should return false")]
        public void ConvertValueNotOfParameterType()
        {
            var value = "";
            var parameterType = typeof(bool);
            var converter = new TypeToBooleanConverter() { ParameterType = parameterType };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value is of the same type than ParameterType, should return true")]
        public void ConvertValueOfParameterType()
        {
            var value = "";
            var parameterType = typeof(string);
            var converter = new TypeToBooleanConverter() { ParameterType = parameterType };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is null, should return false")]
        public void ConvertValueNull()
        {
            object value = null;
            var parameterType = typeof(Class);
            var converter = new TypeToBooleanConverter() { ParameterType = parameterType };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When parameter is null, should return false")]
        public void ConvertParameterNull()
        {
            var value = new Class();
            Type parameterType = null;
            var converter = new TypeToBooleanConverter() { ParameterType = parameterType };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value is typeof classassignablefromclass and parameter is of type Class, should return true")]
        public void ConvertValueAssignableFromParameterType()
        {
            var value = new ClassAssignableFromClass();
            Type parameterType = typeof(Class);
            var converter = new TypeToBooleanConverter() { ParameterType = parameterType };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is typeof class and parameter is of type ClassAssignableFromClass, should return false")]
        public void ConvertValueNotAssignableFromParameterType()
        {
            var value = new Class();
            Type parameterType = typeof(ClassAssignableFromClass);
            var converter = new TypeToBooleanConverter() { ParameterType = parameterType };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value is typeof string and parameter is of type ClassAssignableFromClass, should return false")]
        public void ConvertValueString()
        {
            var value = "stringValue";
            Type parameterType = typeof(int);
            var converter = new TypeToBooleanConverter() { ParameterType = parameterType };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }
    }
}