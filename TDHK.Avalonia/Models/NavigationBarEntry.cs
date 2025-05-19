using System;
using Avalonia.Media;

namespace TDHK.Avalonia.Models;

public class NavigationBarEntry
{
    public Type Type { get; init; }
    public string Name { get; init; }

    public StreamGeometry Icon { get; init; }
}