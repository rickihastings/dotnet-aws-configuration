using CloudManagedConfiguration.Config.Config;
using CloudManagedConfiguration.Config.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloudManagedConfiguration.Config;

public static class ConfigureServices
{
    public static IServiceCollection AddConfiguration(
        this IServiceCollection services,
        IConfigurationBuilder builder,
        string path
    )
    {
        builder.AddSystemsManager(path);

        services.ConfigureSettings<UniversityService>(builder.Build().GetSection("UniversityService"));

        return services;
    }
}