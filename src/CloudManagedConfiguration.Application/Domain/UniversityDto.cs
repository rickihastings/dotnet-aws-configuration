namespace CloudManagedConfiguration.Application.Domain;

public class UniversityDto
{
    public string AlphaTwoCode { get; set; }

    public string Country { get; set; }

    public IEnumerable<string> Domains { get; set; }

    public string Name { get; set; }

    public string? StateProvince { get; set; }

    public IEnumerable<string> WebPages { get; set; }
}