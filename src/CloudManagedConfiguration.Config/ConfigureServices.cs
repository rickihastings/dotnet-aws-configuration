using CloudManagedConfiguration.Config.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CloudManagedConfiguration.Config;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureSettings<TConfig>(this IServiceCollection services, string key)
        where TConfig : class, new()
    {
        if (services == null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        services.AddOptions<TConfig>()
            .BindConfiguration(key)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return services;
    }
    
    public static IServiceCollection AddCloudConfiguration(
        this IServiceCollection services,
        IConfigurationBuilder builder,
        string path
    )
    {
        builder.AddSystemsManager(path);

        return services;
    }

    public static IServiceCollection AddServerlessConfigurationOptions<TConfig>(this IServiceCollection services, string key)
        where TConfig : class, new()
    {
        services.ConfigureSettings<TConfig>(key);
        
        var provider = services.BuildServiceProvider();
        
        var options = provider.GetService(typeof(IOptions<>).MakeGenericType(typeof(TConfig)));
        
        // Retrieve to trigger the validation up front
        var _ = ((IOptions<object>)options).Value;

        return services;
    }
}