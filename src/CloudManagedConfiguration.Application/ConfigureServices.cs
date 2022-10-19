using System.Reflection;
using CloudManagedConfiguration.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CloudManagedConfiguration.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddHttpClient<IUniversitiesService, UniversitiesService>();

        return serviceCollection;
    }
}