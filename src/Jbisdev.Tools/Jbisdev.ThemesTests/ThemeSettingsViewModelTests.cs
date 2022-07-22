using MaterialDesignThemes.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Jbisdev.Themes.Tests
{
    [TestClass()]
    public class ThemeSettingsViewModelTests
    {
        [TestMethod()]
        public void InitializeTest()
        {
            var theme = new ThemeModel
            {
                IsDark = true,
                Primary = "indigo",
                Accent = "yellow"
            };
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme = theme;
            themeManager.Object.Initialize(theme);

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }

        [TestMethod()]
        public void ModifyThemeTest()
        {
            var theme = new ThemeModel
            {
                IsDark = true,
                Primary = "indigo",
                Accent = "yellow"
            };
            var paletteHelperMock = new Mock<PaletteHelper>();
            var themeManager = ThemeSettingsViewModel.Instance;
            themeManager.PaletteHelper = paletteHelperMock.Object;

            themeManager.Initialize(theme);

            paletteHelperMock.Verify(c => c.GetTheme(), Times.Once);
            paletteHelperMock.Verify(c => c.SetTheme(It.IsAny<MaterialDesignThemes.Wpf.ITheme>()), Times.Once);
        }

        [TestMethod("Should Update Theme on Primary Changed")]
        public void PrimaryChangedShouldUpdateTheme()
        {
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme.Primary = themeManager.Object.Swatches.First().Name;

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }

        [TestMethod("Should Update Theme on Accent Changed")]
        public void AccentChangedShouldUpdateTheme()
        {
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme.Accent = themeManager.Object.Swatches.First().Name;

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }

        [TestMethod("Should Update Theme on IsColorAdjusted Changed")]
        public void IsColorAdjustedChangedShouldUpdateTheme()
        {
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme.IsColorAdjusted = !themeManager.Object.Theme.IsColorAdjusted;

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }

        [TestMethod("Should Update Theme on DesiredContrastRatio Changed")]
        public void DesiredContrastRatioChangedShouldUpdateTheme()
        {
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme.DesiredContrastRatio += 1;

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }

        [TestMethod("Should Update Theme on IsDark Changed")]
        public void IsDarkChangedShouldUpdateTheme()
        {
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme.IsDark = !themeManager.Object.Theme.IsDark;

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }

        [TestMethod("Should Update Theme on ContrastValue Changed")]
        public void ContrastValueChangedShouldUpdateTheme()
        {
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme.ContrastValue = themeManager.Object.ContrastValues.First(c => c != themeManager.Object.Theme.ContrastValue);

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }

        [TestMethod("Should Update Theme on ColorSelectionValue Changed")]
        public void ColorSelectionValueChangedShouldUpdateTheme()
        {
            var themeManager = new Mock<ThemeSettingsViewModel>();
            themeManager.Object.Theme.ColorSelectionValue += 1;

            themeManager.Verify(c => c.ModifyTheme(It.IsAny<Action<MaterialDesignThemes.Wpf.ITheme>>()), Times.Once);
        }
    }

    public class PaletteHelperStub : PaletteHelper
    {
        public override MaterialDesignThemes.Wpf.ITheme GetTheme()
        {
            return base.GetTheme();
        }

        public override IThemeManager GetThemeManager()
        {
            return base.GetThemeManager();
        }

        public override void SetTheme(MaterialDesignThemes.Wpf.ITheme theme)
        {
            base.SetTheme(theme);
        }
    }
}