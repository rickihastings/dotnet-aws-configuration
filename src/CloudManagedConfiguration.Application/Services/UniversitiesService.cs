using System.Net.Http.Json;
using AutoMapper;
using CloudManagedConfiguration.Application.Domain;
using CloudManagedConfiguration.Config.Options;
using Microsoft.Extensions.Options;

namespace CloudManagedConfiguration.Application.Services;

public interface IUniversitiesService
{
    Task<IEnumerable<UniversityDto>> GetUniversities();
}

public class UniversitiesService : IUniversitiesService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly string _remoteServiceBaseUrl;

    public UniversitiesService(HttpClient httpClient, IMapper mapper, IOptions<UniversityServiceOptions> config)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        _remoteServiceBaseUrl = config.Value.Endpoint;
    }

    public async Task<IEnumerable<UniversityDto>> GetUniversities()
    {
        var universities = await _httpClient.GetFromJsonAsync<IEnumerable<University>?>(_remoteServiceBaseUrl);

        return universities?.Select(university => _mapper.Map<UniversityDto>(university)) ?? 
               Array.Empty<UniversityDto>();
    }
}