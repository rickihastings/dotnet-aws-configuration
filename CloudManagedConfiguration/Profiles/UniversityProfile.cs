using AutoMapper;
using CloudManagedConfiguration.Domain;

namespace CloudManagedConfiguration.Profiles;

public class UniversityProfile : Profile
{
    public UniversityProfile()
    {
        CreateMap<University, UniversityDto>();
    }
}