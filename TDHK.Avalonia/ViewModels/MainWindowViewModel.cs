using System;
using Microsoft.Extensions.DependencyInjection;
using TDHK.Avalonia.Services.Navigation;
using TDHK.Common.ViewModels;

namespace TDHK.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly IServiceProvider _serviceProvider;
    private readonly INavigationService _navigationService;

    public ViewModelBase ActiveViewModel { get; set; }

    [Obsolete("Only for design purposes")]
    public MainWindowViewModel() { }
    public MainWindowViewModel(INavigationService navigationService, IServiceProvider serviceProvider)
    {
        _navigationService = navigationService;
        _serviceProvider = serviceProvider;
    }

    public void NavigateToPage(Type pageType)
    {
        if (_navigationService != null
            && _serviceProvider.GetRequiredService(pageType) is NavigableViewModel vm)
            _navigationService.Navigate(vm);
    }
}