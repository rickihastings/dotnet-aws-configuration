using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CloudManagedConfiguration.Config.Extensions;

public static class ConfigurationExtensions
{
    public static IServiceCollection ConfigureSettings<TConfig>(this IServiceCollection services, IConfiguration configuration)
        where TConfig : class, new()
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }
        
        if (configuration == null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        var config = new TConfig();
        
        configuration.Bind(config);
        
        services.AddSingleton(config);
        
        return services;
    }
}