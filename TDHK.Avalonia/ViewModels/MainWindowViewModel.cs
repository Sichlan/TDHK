using System;
using Microsoft.Extensions.DependencyInjection;
using TDHK.Avalonia.Services.Navigation;
using TDHK.Common.ViewModels;

namespace TDHK.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;
    private readonly INavigationService _navigationService;

    public ViewModelBase ActiveViewModel => _navigationService.ActiveViewModel;

    public MainWindowViewModel(INavigationService navigationService, IServiceProvider serviceProvider)
    {
        _navigationService = navigationService;
        _serviceProvider = serviceProvider;

        _navigationService.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(_navigationService.ActiveViewModel))
                OnPropertyChanged(nameof(ActiveViewModel));
        };

        NavigateToPage(typeof(TDHKCharacterSheetViewModel));
    }

    public void NavigateToPage(Type pageType)
    {
        if (_navigationService != null
            && _serviceProvider.GetRequiredService(pageType) is NavigableViewModel vm)
            _navigationService.Navigate(vm);
    }
}