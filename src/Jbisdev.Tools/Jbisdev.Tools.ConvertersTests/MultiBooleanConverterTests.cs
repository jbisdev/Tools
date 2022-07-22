using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class MultiBooleanConverterTests
    {
        [TestMethod("Convert : When values are true, true and false, should return false")]
        public void ConvertAtLeastOneValueFalse()
        {
            var values = new object[] { true, true, false };
            var converter = new MultiBooleanConverter();

            var result = (bool)converter.Convert(values, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When values are true, true, true, should return true")]
        public void ConvertAllValuesTrue()
        {
            var values = new object[] { true, true, true };
            var converter = new MultiBooleanConverter();

            var result = (bool)converter.Convert(values, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When values are false, false, false, should return false")]
        public void ConvertAllValuesFalse()
        {
            var values = new object[] { false, false, false };
            var converter = new MultiBooleanConverter();

            var result = (bool)converter.Convert(values, null, null, null);

            Assert.IsFalse(result);
        }
    }
}