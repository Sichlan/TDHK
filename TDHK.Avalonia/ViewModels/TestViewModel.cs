using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Avalonia;
using Avalonia.Media;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TDHK.Avalonia.Helpers.Attributes;
using TDHK.Common.Services;
using TDHK.Common.Services.UserInformationService;

namespace TDHK.Avalonia.ViewModels;

[NavigableMenuItem("Test", "LayerRegular")]
public class TestViewModel : NavigableViewModel
{
    private readonly IDispatcherService _dispatcherService;
    private readonly IUserInformationMessageService _userInformationMessageService;
    public ICommand PopulateCommand { get; }
    public ICommand DeleteCommand { get; }
    public ICommand FireUpdatesCommand { get; }

    public ObservableCollection<ChildGeometryEntry> Children { get; }

    public TestViewModel(IUserInformationMessageService userInformationMessageService)
    {
        _userInformationMessageService = userInformationMessageService;

        Children = [];

        PopulateCommand = new RelayCommand(ExecutePopulateCommand);
        DeleteCommand = new RelayCommand(ExecuteDeleteCommand);
        FireUpdatesCommand = new RelayCommand(ExecuteFireUpdatesCommand);
    }

    private void ExecuteFireUpdatesCommand()
    {
        Stopwatch sw = Stopwatch.StartNew();
        foreach (var child in Children)
        {
            child.Randomize();
        }

        Dispatcher.UIThread.Invoke(() =>
        {
            sw.Stop();

            Debug.WriteLine("Took " + sw.ElapsedMilliseconds + " ms");
            // _userInformationMessageService.AddDisplayMessage("Took " + sw.ElapsedMilliseconds + " ms", InformationType.Information);
        }, DispatcherPriority.Loaded);
    }

    private void ExecuteDeleteCommand()
    {
        Children.Clear();
    }

    private void ExecutePopulateCommand()
    {
        var random = new Random();
        Stopwatch sw = Stopwatch.StartNew();
        for (var i = 0; i < 100_000; i++)
        {
            var child = new ChildGeometryEntry(random);
            child.Randomize();
            Children.Add(child);
        }

        Dispatcher.UIThread.Invoke(() =>
        {
            sw.Stop();

            Debug.WriteLine("Took " + sw.ElapsedMilliseconds + " ms");
            // _userInformationMessageService.AddDisplayMessage("Took " + sw.ElapsedMilliseconds + " ms", InformationType.Information);
        }, DispatcherPriority.Loaded);
    }
}

public partial class ChildGeometryEntry : ObservableObject
{
    private readonly Random _random;

    [ObservableProperty] private double _height;
    [ObservableProperty] private double _width;
    [ObservableProperty] private Thickness _margin;
    [ObservableProperty] private SolidColorBrush _background;

    public ChildGeometryEntry(Random random)
    {
        _random = random;
    }

    public void Randomize()
    {
        var rgb = new byte[3];
        _random.NextBytes(rgb);
        Height = _random.NextDouble() * 50;
        Width = _random.NextDouble() * 50;
        Margin = new Thickness(_random.NextDouble() * 500, _random.NextDouble() * 500, 0, 0);
        Background = new SolidColorBrush(Color.FromRgb(rgb[0], rgb[1], rgb[2]));
    }
}