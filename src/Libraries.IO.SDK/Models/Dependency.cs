using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class Dependency
{
    [JsonPropertyName("project_name")]
    public string ProjectName { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("platform")]
    public string Platform { get; set; } = string.Empty;

    [JsonPropertyName("requirements")]
    public string Requirements { get; set; } = string.Empty;

    [JsonPropertyName("latest_stable")]
    public string LatestStable { get; set; } = string.Empty;

    [JsonPropertyName("latest")]
    public string Latest { get; set; } = string.Empty;

    [JsonPropertyName("deprecated")]
    public bool Deprecated { get; set; }

    [JsonPropertyName("outdated")]
    public bool Outdated { get; set; }

    [JsonPropertyName("filepath")]
    public string Filepath { get; set; } = string.Empty;

    [JsonPropertyName("kind")]
    public string Kind { get; set; } = string.Empty;

    [JsonPropertyName("optional")]
    public bool Optional { get; set; }

    [JsonPropertyName("normalized_licenses")]
    public List<string> NormalizedLicenses { get; set; } = [];
}
