using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class StringToDoubleConverterTests
    {
        [TestMethod("Convert  : When value is not double, should return null")]
        public void ConvertNotDoubleValue()
        {
            var value = "value";
            var converter = new StringToDoubleConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.IsNull(result);
        }

        [DataTestMethod]
        [DataRow(1, "1,000", DisplayName = "Convert : When value is 1, should return 1,000 in double format")]
        [DataRow(-10.78d, "-10,780", DisplayName = "Convert : When value is -10.78, should return -10,780 in double format")]
        [DataRow(24.6986d, "24,699", DisplayName = "Convert : When value is 24.6986, should return 24,6986 in double format")]
        public void Convert(double value, string expected)
        {
            var doubleExpected = SetToDouble(expected);
            var converter = new StringToDoubleConverter();

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(doubleExpected, result);
        }

        private string SetToDouble(string value)
        {
            var newValue = value;
            if (value.Contains(",") && Thread.CurrentThread.CurrentCulture.Name == "en-US")
                newValue = value.Replace(',', '.');
            return newValue;
        }
    }
}