using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TDHK.Common.Services;
using TDHK.Common.Services.UserInformationService;
using TDHK.ModernUi.Services;

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