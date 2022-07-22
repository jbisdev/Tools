using MaterialDesignColors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Windows.Media;

namespace Jbisdev.Themes.Tests
{
    [TestClass()]
    public class ColorToSwatchConverterTests
    {
        [DataTestMethod()]
        [DataRow("indigo", "indigo")]
        [DataRow("red", "red")]
        [DataRow("green", "green")]
        [DataRow("yellow", "yellow")]
        [DataRow("not in color list", null)]
        public void ConvertTest(string colorName, string expectedColorName)
        {
            Swatch expected = expectedColorName == null
                ? null
                : CreateSwatch(expectedColorName);
            var converter = new ColorToSwatchConverter
            {
                Swatches = new List<Swatch>
                {
                    CreateSwatch("indigo"),
                    CreateSwatch("red"),
                    CreateSwatch("green"),
                    CreateSwatch("yellow"),
                }
            };

            var result = converter.Convert(colorName, null, null, null) as Swatch;

            Assert.AreEqual(expected?.Name, result?.Name);
        }

        [DataTestMethod()]
        [DataRow("indigo", "indigo")]
        [DataRow("red", "red")]
        [DataRow("green", "green")]
        [DataRow("yellow", "yellow")]
        public void ConvertBackTest(string colorName, string expectedColorName)
        {
            var swatch = CreateSwatch(expectedColorName);
            var converter = new ColorToSwatchConverter
            {
                Swatches = new List<Swatch>
                {
                    CreateSwatch("indigo"),
                    CreateSwatch("red"),
                    CreateSwatch("green"),
                    CreateSwatch("yellow"),
                }
            };

            var result = converter.ConvertBack(swatch, null, null, null);

            Assert.AreEqual(swatch.Name, result);
        }

        private static Swatch CreateSwatch(string expectedColorName)
        {
            return new Swatch(expectedColorName,

                new List<Hue>
                    {
                    new Hue(expectedColorName, Colors.Transparent, Colors.Transparent)
                            },
                            new List<Hue>
                            {
                    new Hue(expectedColorName, Colors.Transparent, Colors.Transparent)
                            });
        }
    }
}