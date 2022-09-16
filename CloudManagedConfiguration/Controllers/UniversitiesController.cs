using CloudManagedConfiguration.Domain;
using CloudManagedConfiguration.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudManagedConfiguration.Controllers;

[ApiController]
[Route("universities")]
public class UniversitiesController : ControllerBase
{
    private readonly IUniversitiesService _universitiesService;
    
    public UniversitiesController(IUniversitiesService universitiesService)
    {
        _universitiesService = universitiesService;
    }

    [HttpGet]
    public async Task<IEnumerable<UniversityDto>> GetAsync()
    {
        return await _universitiesService.GetUniversities();
    }
}