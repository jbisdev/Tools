using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class InverseBooleanConverterTests
    {
        [TestMethod("Convert : When value is false, should return true")]
        public void ConvertValueFalse()
        {
            var value = false;
            var converter = new InverseBooleanConverter();

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is true, should return false")]
        public void ConvertValueTrue()
        {
            var value = true;
            var converter = new InverseBooleanConverter();

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("ConvertBack : When value is false, should return true")]
        public void ConvertBackValueFalse()
        {
            var value = false;
            var converter = new InverseBooleanConverter();

            var result = (bool)converter.ConvertBack(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("ConvertBack : When value is true, should return false")]
        public void ConvertBackValueTrue()
        {
            var value = true;
            var converter = new InverseBooleanConverter();

            var result = (bool)converter.ConvertBack(value, null, null, null);

            Assert.IsFalse(result);
        }
    }
}