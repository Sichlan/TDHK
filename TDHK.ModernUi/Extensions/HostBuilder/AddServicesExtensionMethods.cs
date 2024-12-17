using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TDHK.ModernUi.Helpers;
using TDHK.ModernUi.Services;
using TDHK.ModernUi.Services.UserInformationService;

namespace TDHK.ModernUi.Extensions.HostBuilder;

public static class AddServicesExtensionMethods
{
    public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices(services =>
        {
            services.AddSingleton<IUserInformationMessageService, ViewModelUserInformationMessageService>();
            services.AddSingleton<IDispatcherService, DispatcherService>();
        });

        return hostBuilder;
    }
}