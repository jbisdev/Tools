using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace Jbisdev.Themes
{
    public interface ITheme
    {
        string Accent { get; set; }
        ColorSelection ColorSelectionValue { get; set; }
        IEnumerable<ColorSelection> ColorSelectionValues { get; }
        Contrast ContrastValue { get; set; }
        IEnumerable<Contrast> ContrastValues { get; }
        float DesiredContrastRatio { get; set; }
        bool IsColorAdjusted { get; set; }
        bool IsDark { get; set; }
        string Primary { get; set; }
    }
}