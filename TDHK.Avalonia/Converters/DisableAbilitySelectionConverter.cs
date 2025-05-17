using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;

namespace TDHK.Avalonia.Converters;

public class DisableAbilitySelectionConverter : IMultiValueConverter
{
    public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
    {
        return !values.Cast<string>()
            .Where(x => !string.IsNullOrEmpty(x))
            .GroupBy(x => x)
            .Any(x => x.Count() > 1);
    }
}