using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Jbisdev.Themes
{
    public class ThemeModel : ITheme, INotifyPropertyChanged
    {
        private string _accent;
        private ColorSelection _colorSelectionValue;
        private Contrast _contrastValue;
        private float _desiredContrastRatio;
        private bool _isColorAdjusted;
        private bool _isDark;
        private string _primary;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Accent
        { get => _accent; set { _accent = value; OnPropertyChanged(); } }

        public ColorSelection ColorSelectionValue
        { get => _colorSelectionValue; set { _colorSelectionValue = value; OnPropertyChanged(); } }

        public IEnumerable<ColorSelection> ColorSelectionValues => Enum.GetValues(typeof(ColorSelection)).Cast<ColorSelection>();

        public Contrast ContrastValue
        { get => _contrastValue; set { _contrastValue = value; OnPropertyChanged(); } }

        public IEnumerable<Contrast> ContrastValues => Enum.GetValues(typeof(Contrast)).Cast<Contrast>();

        public float DesiredContrastRatio
        { get => _desiredContrastRatio; set { _desiredContrastRatio = value; OnPropertyChanged(); } }

        public bool IsColorAdjusted
        { get => _isColorAdjusted; set { _isColorAdjusted = value; OnPropertyChanged(); } }

        public bool IsDark
        { get => _isDark; set { _isDark = value; OnPropertyChanged(); } }

        public string Primary
        { get => _primary; set { _primary = value; OnPropertyChanged(); } }

        public override bool Equals(object obj)
        {
            if (obj is not ThemeModel theme)
                return false;
            return theme.Accent == Accent
                && theme.ColorSelectionValue == ColorSelectionValue
                && theme.ContrastValue == ContrastValue
                && theme.DesiredContrastRatio == DesiredContrastRatio
                && theme.IsColorAdjusted == IsColorAdjusted
                && theme.IsDark == IsDark
                && theme.Primary == Primary;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}