using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Jbisdev.Themes
{
    public class ThemeSettingsViewModel : INotifyPropertyChanged
    {
        private ITheme _theme = new ThemeModel();
        private PaletteHelper _palettehelper = new();

        protected ThemeSettingsViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;

            PropertyChanged += OnPropertyChanged;
            if (Theme is not INotifyPropertyChanged theme)
                return;
            theme.PropertyChanged += OnPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static ThemeSettingsViewModel Instance
        { get { return Nested.MainInstance; } }

        public ITheme Theme
        { get => _theme; set { _theme = value; OnPropertyChanged(); } }

        public IEnumerable<Contrast> ContrastValues => Enum.GetValues(typeof(Contrast)).Cast<Contrast>();

        public IEnumerable<Swatch> Swatches { get; }

        public PaletteHelper PaletteHelper
        { get => _palettehelper; set { _palettehelper = value; OnPropertyChanged(); } }

        public void Initialize(ITheme theme)
        {
            Theme = theme;
            var primary = Swatches.FirstOrDefault(s => s.Name.ToLower().Equals(Theme.Primary.ToLower()));
            var accent = Swatches.FirstOrDefault(s => s.Name.ToLower().Equals(Theme.Accent.ToLower()));
            ModifyTheme(t =>
            {
                if (t is Theme internalTheme)
                {
                    internalTheme.SetBaseTheme(Theme.IsDark ? MaterialDesignThemes.Wpf.Theme.Dark : MaterialDesignThemes.Wpf.Theme.Light);
                    internalTheme.SetPrimaryColor(primary.ExemplarHue.Color);
                    internalTheme.SetSecondaryColor(accent.ExemplarHue.Color);
                    internalTheme.ColorAdjustment = Theme.IsColorAdjusted ? new ColorAdjustment
                    {
                        DesiredContrastRatio = Theme.DesiredContrastRatio,
                        Contrast = Theme.ContrastValue,
                        Colors = Theme.ColorSelectionValue
                    } : null;
                }
            });
        }

        public virtual void ModifyTheme(Action<MaterialDesignThemes.Wpf.ITheme> modificationAction)
        {
            var theme = PaletteHelper.GetTheme();

            modificationAction?.Invoke(theme);

            PaletteHelper.SetTheme(theme);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(ThemeModel.Primary)))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme)
                    {
                        var primary = Swatches.FirstOrDefault(s => s.Name.ToLower().Equals(Theme.Primary.ToLower()));
                        internalTheme.SetPrimaryColor(primary.ExemplarHue.Color);
                    }
                });
            }
            if (e.PropertyName.Equals(nameof(ThemeModel.Accent)))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme)
                    {
                        var accent = Swatches.FirstOrDefault(s => s.Name.ToLower().Equals(Theme.Accent.ToLower()));
                        internalTheme.SetSecondaryColor(accent.ExemplarHue.Color);
                    }
                });
            }
            if (e.PropertyName.Equals(nameof(ThemeModel.IsColorAdjusted)))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme)
                    {
                        internalTheme.ColorAdjustment = Theme.IsColorAdjusted
                            ? new ColorAdjustment
                            {
                                DesiredContrastRatio = Theme.DesiredContrastRatio,
                                Contrast = Theme.ContrastValue,
                                Colors = Theme.ColorSelectionValue
                            }
                            : null;
                    }
                });
            }
            if (e.PropertyName.Equals(nameof(ThemeModel.DesiredContrastRatio)))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme && internalTheme.ColorAdjustment != null)
                        internalTheme.ColorAdjustment.DesiredContrastRatio = Theme.DesiredContrastRatio;
                });
            }
            if (e.PropertyName.Equals(nameof(ThemeModel.IsDark)))
            {
                ModifyTheme(theme => theme.SetBaseTheme(Theme.IsDark ? MaterialDesignThemes.Wpf.Theme.Dark : MaterialDesignThemes.Wpf.Theme.Light));
            }
            if (e.PropertyName.Equals(nameof(ThemeModel.ContrastValue)))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme && internalTheme.ColorAdjustment != null)
                        internalTheme.ColorAdjustment.Contrast = Theme.ContrastValue;
                });
            }
            if (e.PropertyName.Equals(nameof(ThemeModel.ColorSelectionValue)))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme && internalTheme.ColorAdjustment != null)
                        internalTheme.ColorAdjustment.Colors = Theme.ColorSelectionValue;
                });
            }
        }

        private class Nested
        {
            /// <summary>
            /// The logger instance
            /// </summary>
            internal static readonly ThemeSettingsViewModel MainInstance = new();

            // Explicit static constructor to tell C# compiler
            // not to mark type as before field initialized
            /// <summary>
            /// Initializes the <see cref="Nested"/> class.
            /// </summary>
            static Nested()
            {
            }
        }
    }
}