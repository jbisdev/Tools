using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class IsGreaterThanConverterTests
    {
        [DataTestMethod()]
        [DataRow(null, DisplayName = "Convert : When value is null, should return false")]
        [DataRow("", DisplayName = "Convert : When value is a string, should return false")]
        [DataRow(true, DisplayName = "Convert : When value is bool, should return false")]
        public void ConvertIncorrectTypeValue(object value)
        {
            var converter = new IsGreaterThanConverter();

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value is 7 and triggerValue is 5, should return true")]
        public void ConvertIntNumberGreaterThanTriggerValue()
        {
            var value = 7;
            var triggerValue = 5;
            var converter = new IsGreaterThanConverter() { TriggerValue = triggerValue };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is 7.5f and triggerValue is 5, should return true")]
        public void ConvertFloatNumberGreaterThanTriggerValue()
        {
            var value = 7.5f;
            var triggerValue = 5;
            var converter = new IsGreaterThanConverter() { TriggerValue = triggerValue };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is 7.5d and triggerValue is 5, should return true")]
        public void ConvertDoubleNumberGreaterThanTriggerValue()
        {
            var value = 7.5d;
            var triggerValue = 5;
            var converter = new IsGreaterThanConverter() { TriggerValue = triggerValue };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is 7.5m and triggerValue is 5, should return true")]
        public void ConvertDecimalNumberGreaterThanTriggerValue()
        {
            var value = 7.5m;
            var triggerValue = 5;
            var converter = new IsGreaterThanConverter() { TriggerValue = triggerValue };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsTrue(result);
        }

        [TestMethod("Convert : When value is 5 and triggerValue is 5, should return false")]
        public void ConvertIntNumberSameThanTriggerValue()
        {
            var value = 5;
            var triggerValue = 5;
            var converter = new IsGreaterThanConverter() { TriggerValue = triggerValue };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }

        [TestMethod("Convert : When value is 3 and triggerValue is 5, should return false")]
        public void ConvertIntNumberLeastThanTriggerValue()
        {
            var value = 3;
            var triggerValue = 5;
            var converter = new IsGreaterThanConverter() { TriggerValue = triggerValue };

            var result = (bool)converter.Convert(value, null, null, null);

            Assert.IsFalse(result);
        }
    }
}