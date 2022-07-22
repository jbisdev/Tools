using MaterialDesignThemes.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jbisdev.Themes.Tests
{
    [TestClass()]
    public class ThemeModelTests
    {
        [TestMethod("Equals : When accent is different, should return false")]
        public void EqualsAccentDifferent()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent1",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent2",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };

            var result = theme1.Equals(theme2);

            Assert.IsFalse(result);
        }

        [TestMethod("Equals : When iscoloradjusted is different, should return false")]
        public void EqualsIsColorAdjustedDifferent()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = true,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };

            var result = theme1.Equals(theme2);

            Assert.IsFalse(result);
        }

        [TestMethod("Equals : When colorselectionvalue is different, should return false")]
        public void EqualsColorSelectionValueDifferent()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                ColorSelectionValue = ColorSelection.Primary,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                ColorSelectionValue = ColorSelection.Secondary,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };

            var result = theme1.Equals(theme2);

            Assert.IsFalse(result);
        }

        [TestMethod("Equals : When desired contrast ratio is different, should return false")]
        public void EqualsDesiredContrastRatioDifferent()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = true,
                DesiredContrastRatio = 2,
                IsDark = false,
                Primary = "primary"
            };

            var result = theme1.Equals(theme2);

            Assert.IsFalse(result);
        }

        [TestMethod("Equals : When contrast value is different, should return false")]
        public void EqualsIsContrastValueDifferent()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                ContrastValue = Contrast.Low,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                ContrastValue = Contrast.Medium,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };

            var result = theme1.Equals(theme2);

            Assert.IsFalse(result);
        }

        [TestMethod("Equals : When isdark is different, should return false")]
        public void EqualsIsIsDarkDifferent()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = true,
                Primary = "primary"
            };

            var result = theme1.Equals(theme2);

            Assert.IsFalse(result);
        }

        [TestMethod("Equals : When primary is different, should return false")]
        public void EqualsPrimaryDifferent()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary2"
            };

            var result = theme1.Equals(theme2);

            Assert.IsFalse(result);
        }

        [TestMethod("Equals : When no differences, should return true")]
        public void EqualsNoDifferences()
        {
            var theme1 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };
            var theme2 = new ThemeModel()
            {
                Accent = "accent",
                IsColorAdjusted = false,
                DesiredContrastRatio = 0,
                IsDark = false,
                Primary = "primary"
            };

            var result = theme1.Equals(theme2);

            Assert.IsTrue(result);
        }
    }
}