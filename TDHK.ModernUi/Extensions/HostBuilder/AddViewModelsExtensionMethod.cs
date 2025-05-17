using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TDHK.Common.Services.UserInformationService;
using TDHK.Common.ViewModels.Users;
using TDHK.ModernUi.ViewModels;

namespace TDHK.ModernUi.Extensions.HostBuilder;

public static class AddViewModelsExtensionMethod
{
    /// <summary>
    /// Extension Method that adds all navigable view models to the host builder.
    /// </summary>
    /// <param name="hostBuilder">The <see cref="IHostBuilder"/> to add the models to.</param>
    /// <returns>The <see cref="IHostBuilder"/> with the registered view models.</returns>
    public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddScoped<MainViewModel>();

            services.AddSingleton<CreateUserMessageViewModel>(s =>
                (message, type, after, details) => CreateUserMessageViewModel(s, message, type, after, details));
        });

        return hostBuilder;
    }

    private static UserMessageViewModel CreateUserMessageViewModel(IServiceProvider s, string message, InformationType type, int? after, string details)
    {
        return new UserMessageViewModel(message, type, after, details,
            s.GetRequiredService<IUserInformationMessageService>());
    }
}