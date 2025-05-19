using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using TDHK.Avalonia.Helpers.Attributes;
using TDHK.Avalonia.Models;
using TDHK.Avalonia.Services.Navigation;
using TDHK.Common.ViewModels;

namespace TDHK.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private NavigationBarEntry _selectedNavigationBarEntry;

    private readonly IServiceProvider _serviceProvider;
    private readonly INavigationService _navigationService;

    public ViewModelBase ActiveViewModel => _navigationService.ActiveViewModel;

    public ObservableCollection<NavigationBarEntry> NavigableViewModels { get; }

    public MainWindowViewModel(INavigationService navigationService, IServiceProvider serviceProvider)
    {
        _navigationService = navigationService;
        _serviceProvider = serviceProvider;

        _navigationService.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName == nameof(_navigationService.ActiveViewModel))
                OnPropertyChanged(nameof(ActiveViewModel));
        };

        NavigableViewModels = BuildNavigationBarEntries([
            typeof(TDHKCharacterSheetViewModel),
            typeof(TestViewModel)
        ]);

        SelectedNavigationBarEntry = NavigableViewModels.First();
    }

    private ObservableCollection<NavigationBarEntry> BuildNavigationBarEntries(List<Type> types)
    {
        var output = new ObservableCollection<NavigationBarEntry>();
        Application.Current!.TryFindResource("DocumentErrorRegular", out object error);

        foreach (var type in types)
        {
            var data = type.GetCustomAttribute<NavigableMenuItemAttribute>();

            object i = null;
            if (data != null)
                Application.Current!.TryFindResource(data?.IconName, out i);

            var entry = new NavigationBarEntry
            {
                Type = type,
                Name = data?.Name ?? "ATTRIBUTE MISSING",
                Icon = (StreamGeometry)(i ?? error)
            };
            output.Add(entry);
        }

        return output;
    }

    private async Task<bool> ExecuteNavigateToPageCommand(Type pageType)
    {
        if (_navigationService == null
            || _serviceProvider.GetRequiredService(pageType) is not NavigableViewModel vm)
            return false;

        await _navigationService.NavigateAsync(vm);

        return true;
    }

    private async void OnNavigationChanged(NavigationBarEntry oldValue, NavigationBarEntry newValue)
    {
        if (!await ExecuteNavigateToPageCommand(newValue.Type))
            SelectedNavigationBarEntry = oldValue;
    }

    partial void OnSelectedNavigationBarEntryChanged(NavigationBarEntry oldValue, NavigationBarEntry newValue)
    {
        OnNavigationChanged(oldValue, newValue);
    }
}