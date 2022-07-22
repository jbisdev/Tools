using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace Jbisdev.Tools.Converters.Tests
{
    [TestClass()]
    public class BooleanToVisibilityConverterTests
    {
        [TestMethod("Convert : When value is not bool, should return Unset")]
        public void ConvertValueNotBool()
        {
            var value = "";
            var converter = new BooleanToVisibilityConverter();
            var expected = DependencyProperty.UnsetValue;

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(true, true, true, Visibility.Hidden,
            DisplayName = "Convert : When value is true, triggerValue is true and isHidden is true, should return hidden")]
        [DataRow(false, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(true, true, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is true, triggerValue is false and isHidden is true, should return collapsed")]
        [DataRow(false, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(true, false, true, Visibility.Visible,
            DisplayName = "Convert : When value is true, triggerValue is false and isHidden is true, should return visible")]
        [DataRow(false, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(true, false, false, Visibility.Visible,
            DisplayName = "Convert : When value is true, triggerValue is false and isHidden is false, should return visible")]
        [DataRow(false, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        public void ConvertValueFalse(bool value, bool triggerValue, bool isHidden, Visibility expected)
        {
            var converter = new BooleanToVisibilityConverter() { IsHidden = isHidden, TriggerValue = triggerValue };

            var result = converter.Convert(value, null, null, null);

            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class MultiBooleanToVisibilityConverterTests
    {
        [DataTestMethod()]
        [DataRow("", true, false, DisplayName = "Convert : When there are three values and value1 is not bool, should return Unset")]
        [DataRow(true, "", false, DisplayName = "Convert : When there are three values and value2 is not bool, should return Unset")]
        [DataRow(false, true, "", DisplayName = "Convert : When there are three values and value3 is not bool, should return Unset")]
        public void ConvertValuesNotBool(object value1, object value2, object value3)
        {
            var values = new object[] { value1, value2, value3 };
            var converter = new MultiBooleanToVisibilityConverter();
            var expected = DependencyProperty.UnsetValue;

            var result = converter.Convert(values, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [TestMethod("Convert : When values null, should return Unset")]
        public void ConvertValuesNull()
        {
            object[] values = null;
            var converter = new MultiBooleanToVisibilityConverter();
            var expected = DependencyProperty.UnsetValue;

            var result = converter.Convert(values, null, null, null);

            Assert.AreEqual(expected, result);
        }

        [DataTestMethod]
        [DataRow(true, true, true, true, true, Visibility.Hidden,
            DisplayName = "Convert : When value is true, triggerValue is true and isHidden is true, should return hidden")]
        [DataRow(true, true, false, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(true, false, false, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(false, true, false, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(false, false, true, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(false, false, false, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(false, true, true, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(true, false, true, false, true, Visibility.Hidden,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return hidden")]
        [DataRow(true, true, true, true, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is true, triggerValue is false and isHidden is true, should return collapsed")]
        [DataRow(true, true, false, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(true, false, false, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(false, true, false, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(false, false, true, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(false, false, false, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(false, true, true, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(true, false, true, false, false, Visibility.Collapsed,
            DisplayName = "Convert : When value is false, triggerValue is false and isHidden is false, should return collapsed")]
        [DataRow(true, true, true, false, true, Visibility.Visible,
            DisplayName = "Convert : When value is true, triggerValue is false and isHidden is true, should return visible")]
        [DataRow(true, true, false, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(true, false, false, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(false, true, false, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(false, false, true, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(false, false, false, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(false, true, true, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(true, false, true, true, false, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is false, should return visible")]
        [DataRow(true, true, true, false, false, Visibility.Visible,
            DisplayName = "Convert : When value is true, triggerValue is false and isHidden is false, should return visible")]
        [DataRow(true, true, false, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        [DataRow(true, false, false, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        [DataRow(false, true, false, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        [DataRow(false, false, true, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        [DataRow(false, false, false, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        [DataRow(false, true, true, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        [DataRow(true, false, true, true, true, Visibility.Visible,
            DisplayName = "Convert : When value is false, triggerValue is true and isHidden is true, should return visible")]
        public void ConvertValueFalse(bool value1, bool value2, bool value3, bool triggerValue, bool isHidden, Visibility expected)
        {
            var values = new object[] { value1, value2, value3 };
            var converter = new MultiBooleanToVisibilityConverter() { IsHidden = isHidden, TriggerValue = triggerValue };

            var result = converter.Convert(values, null, null, null);

            Assert.AreEqual(expected, result);
        }
    }
}