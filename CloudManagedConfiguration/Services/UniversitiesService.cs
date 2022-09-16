using AutoMapper;
using CloudManagedConfiguration.Domain;

namespace CloudManagedConfiguration.Services;

public interface IUniversitiesService
{
    Task<IEnumerable<UniversityDto>> GetUniversities();
}

public class UniversitiesService : IUniversitiesService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _mapper;
    private readonly string _remoteServiceBaseUrl;

    public UniversitiesService(HttpClient httpClient, IMapper mapper, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _mapper = mapper;
        _remoteServiceBaseUrl = configuration.GetValue<string>("UniversityService:Endpoint");
    }

    public async Task<IEnumerable<UniversityDto>> GetUniversities()
    {
        var universities = await _httpClient.GetFromJsonAsync<IEnumerable<University>?>(_remoteServiceBaseUrl);

        return universities?.Select(university => _mapper.Map<UniversityDto>(university)) ??
               Array.Empty<UniversityDto>();
    }
}