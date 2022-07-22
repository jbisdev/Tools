using MaterialDesignColors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Jbisdev.Themes
{
    public class ColorToSwatchConverter : DependencyObject, IValueConverter
    {
        public IEnumerable<Swatch> Swatches
        {
            get { return (IEnumerable<Swatch>)GetValue(SwatchesProperty); }
            set { SetValue(SwatchesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Swatches.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SwatchesProperty =
            DependencyProperty.Register("Swatches", typeof(IEnumerable<Swatch>), typeof(ColorToSwatchConverter), new PropertyMetadata(ThemeSettingsViewModel.Instance.Swatches));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = value.ToString();
            return Swatches?.FirstOrDefault(s => s.Name.ToLower().Equals(color.ToLower()));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value as Swatch)?.Name;
        }
    }
}