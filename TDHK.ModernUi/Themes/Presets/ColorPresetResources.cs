﻿using System;
using System.Windows;
using SourceChord.FluentWPF;

namespace TDHK.ModernUi.Themes.Presets;

public class ColorPresetResources : ResourceDictionary
{
    private ApplicationTheme _targetTheme;

    public ColorPresetResources()
    {
        WeakEventManager<PresetManager, EventArgs>.AddHandler(
            PresetManager.Current,
            nameof(PresetManager.ColorPresetChanged),
            OnCurrentPresetChanged);

        ApplyCurrentPreset();
    }

    public ApplicationTheme TargetTheme
    {
        get => _targetTheme;
        set
        {
            if (_targetTheme != value)
            {
                _targetTheme = value;
                ApplyCurrentPreset();
            }
        }
    }

    private void OnCurrentPresetChanged(object sender, EventArgs e)
    {
        ApplyCurrentPreset();
    }

    private void ApplyCurrentPreset()
    {
        if (MergedDictionaries.Count > 0)
        {
            MergedDictionaries.Clear();
        }

        var assemblyName = GetType().Assembly.GetName().Name;
        var currentPreset = PresetManager.Current.ColorPreset;
        var source = new Uri($"pack://application:,,,/{assemblyName};component/Themes/Presets/{currentPreset}/{TargetTheme}.xaml");
        var rd = new ResourceDictionary {Source = source};
        MergedDictionaries.Add(rd);
    }
}