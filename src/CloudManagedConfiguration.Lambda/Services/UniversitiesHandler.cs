using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using CloudManagedConfiguration.Application.Domain;
using CloudManagedConfiguration.Application.Services;
using CloudManagedConfiguration.Config.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CloudManagedConfiguration.Lambda;

public interface IUniversitiesHandler
{
    Task<APIGatewayProxyResponse> ExecuteAsync();
}

public class UniversitiesHandler : IUniversitiesHandler
{
    private readonly ILogger<UniversitiesHandler> _logger;
    private readonly IUniversitiesService _universitiesService;

    public UniversitiesHandler(ILogger<UniversitiesHandler> logger, IUniversitiesService universitiesService)
    {
        _logger = logger;
        _universitiesService = universitiesService;
    }

    public async Task<APIGatewayProxyResponse> ExecuteAsync()
    {
        _logger.LogDebug("ExecuteAsync invoked");

        var response = await _universitiesService.GetUniversities();

        return new APIGatewayProxyResponse
        {
            Body = JsonSerializer.Serialize(response),
            StatusCode = 200,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}