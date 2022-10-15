using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CloudManagedConfiguration.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());

        return serviceCollection;
    }
}