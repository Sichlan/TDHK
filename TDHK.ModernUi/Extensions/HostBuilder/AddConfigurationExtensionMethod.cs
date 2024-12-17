using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TDHK.ModernUi.Views;

namespace TDHK.ModernUi.Extensions.HostBuilder;

public static class AddConfigurationExtensionMethod
{
    public static IHostBuilder AddConfiguration(this IHostBuilder hostBuilder, string[] args)
    {
        hostBuilder.ConfigureHostConfiguration(builder =>
            {
                if (args != null)
                {
                    builder.AddCommandLine(args);
                }
            })
            .ConfigureAppConfiguration((builder, config) =>
            {
                // config.AddJsonFile("appsettings.json", false, true);
                config.AddJsonFile($"appsettings.{builder.HostingEnvironment.EnvironmentName}.json", true, true);

                config.AddEnvironmentVariables();
            })
            .ConfigureServices(s => s.AddScoped<MainWindow>());

        return hostBuilder;
    }
}