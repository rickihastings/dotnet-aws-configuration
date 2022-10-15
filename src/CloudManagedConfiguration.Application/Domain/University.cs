using System.Text.Json.Serialization;

namespace CloudManagedConfiguration.Application.Domain;

public class University
{
    [JsonPropertyName("alpha_two_code")]
    public string AlphaTwoCode { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("domains")]
    public IEnumerable<string> Domains { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("state-province")]
    public string? StateProvince { get; set; }

    [JsonPropertyName("web_pages")]
    public IEnumerable<string> WebPages { get; set; }
}