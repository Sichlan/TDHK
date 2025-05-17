using Microsoft.Extensions.DependencyInjection;
using TDHK.Avalonia.Services.Navigation;
using TDHK.Avalonia.ViewModels;

namespace TDHK.Avalonia.Helpers.ExtensionMethods;

public static class ServiceCollectionExtensionMethods
{
    public static void Configure(this IServiceCollection s)
    {
        // View Models
        s.AddSingleton<MainWindowViewModel>();
        s.AddSingleton<TDHKCharacterSheetViewModel>();

        // Services
        s.AddSingleton<INavigationService, NavigationService>();
    }
}