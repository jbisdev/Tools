using System.Windows;
using System.Windows.Controls;

namespace Jbisdev.Themes
{
    /// <summary>
    /// Logique d'interaction pour ThemeSettingsControl.xaml
    /// </summary>
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public partial class ThemeSettingsControl : UserControl
    {
        // Using a DependencyProperty as the backing store for Theme.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register("Theme", typeof(ITheme), typeof(ThemeSettingsControl));

        public ThemeSettingsControl()
        {
            InitializeComponent();
        }

        public ITheme Theme
        {
            get { return (ITheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }
    }
}