using System;

namespace TDHK.Avalonia.Helpers.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class NavigableMenuItemAttribute : Attribute
{
    public string Name { get; }
    public string IconName { get; }

    public NavigableMenuItemAttribute(string name, string iconName)
    {
        Name = name;
        IconName = iconName;
    }

}