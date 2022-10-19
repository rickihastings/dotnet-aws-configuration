using System;
using CloudManagedConfiguration.Application;
using CloudManagedConfiguration.Config;
using CloudManagedConfiguration.Config.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CloudManagedConfiguration.Lambda;

public class Startup
{
    public IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        var configuration = new ConfigurationBuilder().Build();

        // Configuration
        services.AddDefaultAWSOptions(configuration.GetAWSOptions());
        services.AddSingleton<IConfiguration>(configuration);
        
        // Logging
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddConsole();
        });

        // Add services to the container.
        services.AddSingleton<IUniversitiesHandler, UniversitiesHandler>();
        services.AddApplicationServices();

        services.AddServerlessConfigurationOptions<UniversityServiceOptions>(UniversityServiceOptions.Key);
        
        return services.BuildServiceProvider();
    }
}