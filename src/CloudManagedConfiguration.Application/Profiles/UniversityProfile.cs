using AutoMapper;
using CloudManagedConfiguration.Application.Domain;

namespace CloudManagedConfiguration.Application.Profiles;

public class UniversityProfile : Profile
{
    public UniversityProfile()
    {
        CreateMap<University, UniversityDto>();
    }
}