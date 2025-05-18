using Microsoft.Extensions.DependencyInjection;
using TDHK.Avalonia.Services;
using TDHK.Avalonia.Services.Navigation;
using TDHK.Avalonia.ViewModels;
using TDHK.Common.Services;
using TDHK.Common.Services.UserInformationService;
using TDHK.Common.ViewModels.Users;

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
        s.AddSingleton<IDispatcherService, DispatcherService>();
        s.AddSingleton<IUserInformationMessageService, ViewModelUserInformationMessageService>();

        // Delegates
        s.AddSingleton<CreateUserMessageViewModel>(provider =>
            (message, type, after, details) =>
                new UserMessageViewModel(message, type, after, details, provider.GetRequiredService<IUserInformationMessageService>()));
    }
}