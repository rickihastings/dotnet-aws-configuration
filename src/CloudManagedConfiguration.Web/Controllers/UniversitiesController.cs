using CloudManagedConfiguration.Application.Domain;
using CloudManagedConfiguration.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CloudManagedConfiguration.Web.Controllers;

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