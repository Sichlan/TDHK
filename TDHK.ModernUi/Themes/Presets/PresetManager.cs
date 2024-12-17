using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TDHK.ModernUi.Themes.Presets;

public class PresetManager : INotifyPropertyChanged
{
    internal const string DefaultPreset = "Default";

    private string _colorPreset = DefaultPreset;
    private string _shapePreset = DefaultPreset;

    private PresetManager()
    {
    }

    public static PresetManager Current { get; } = new PresetManager();

    public string ColorPreset
    {
        get => _colorPreset;
        set
        {
            if (_colorPreset != value)
            {
                _colorPreset = value;
                OnPropertyChanged();
                ColorPresetChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public string ShapePreset
    {
        get => _shapePreset;
        set
        {
            if (_shapePreset != value)
            {
                _shapePreset = value;
                OnPropertyChanged();
                ShapePresetChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public event EventHandler ColorPresetChanged;
    public event EventHandler ShapePresetChanged;
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}