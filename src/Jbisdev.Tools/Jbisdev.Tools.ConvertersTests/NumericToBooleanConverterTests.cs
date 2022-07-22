using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class NumericToBooleanConverterTests
    {
        [TestMethod("Convert : When value is 0, should return false")]
        public void ConvertValueZero()
        {
            var value = 0;
            var converter = new NumericToBooleanConverter();

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(1, DisplayName = "Convert : When value is 1, should return true")]
        [DataRow(10, DisplayName = "Convert : When value is 1, should return true")]
        [DataRow(10, DisplayName = "Convert : When value is 1, should return true")]
        public void ConvertValueGreaterThanZero(int value)
        {
            var converter = new NumericToBooleanConverter();

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is not an integer, should return null")]
        public void ConvertValueNotInteger()
        {
            var value = "";
            var converter = new NumericToBooleanConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.IsNull(result);
        }
    }
}