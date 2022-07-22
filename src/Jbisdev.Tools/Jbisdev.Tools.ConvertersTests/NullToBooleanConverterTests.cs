using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class NullToBooleanConverterTests
    {
        [TestMethod("Convert : When value is string empty, should return true")]
        public void ConvertEmptyString()
        {
            var value = "";
            var converter = new NullToBooleanConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.IsTrue((bool)result);
        }

        [TestMethod("Convert : When value is null string, should return true")]
        public void ConvertNullString()
        {
            string value = null;
            var converter = new NullToBooleanConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.IsTrue((bool)result);
        }

        [TestMethod("Convert : When value is null, should return true")]
        public void ConvertNullValue()
        {
            object value = null;
            var converter = new NullToBooleanConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.IsTrue((bool)result);
        }

        [TestMethod("Convert : When value is string not null, should return false")]
        public void ConvertNotNullString()
        {
            var empty = "notnull";
            var converter = new NullToBooleanConverter();

            var result = converter.Convert(empty, null, null, null);

            Assert.IsFalse((bool)result);
        }

        [TestMethod("Convert : When value is not null, should return false")]
        public void ConvertTest()
        {
            var value = new object();
            var converter = new NullToBooleanConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.IsFalse((bool)result);
        }
    }
}