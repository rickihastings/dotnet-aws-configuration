using System.ComponentModel.DataAnnotations;

namespace CloudManagedConfiguration.Config.Options;

public class UniversityServiceOptions
{
    public const string Key = "UniversityService";
    
    [Required, Url]
    public string Endpoint { get; set; }
}