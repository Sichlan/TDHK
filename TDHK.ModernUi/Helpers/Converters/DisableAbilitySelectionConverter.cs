using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TDHK.ModernUi.Helpers.Converters;

public class DisableAbilitySelectionConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return !values.Cast<string>()
            .Where(x => !string.IsNullOrEmpty(x))
            .GroupBy(x => x)
            .Any(x => x.Count() > 1);
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new UnreachableException();
    }
}