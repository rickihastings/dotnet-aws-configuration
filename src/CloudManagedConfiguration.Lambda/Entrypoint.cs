using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CloudManagedConfiguration.Lambda;

public class Entrypoint
{
    private readonly IUniversitiesHandler _handler;
    
    public Entrypoint()
    {
        var startup = new Startup();
        var provider = startup.ConfigureServices();

        _handler = provider.GetRequiredService<IUniversitiesHandler>();
    }
    
    // ReSharper disable once UnusedMember.Global, UnusedParameter.Global
    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest apiGatewayProxyEvent)
    {
        return await _handler.ExecuteAsync();
    }
}