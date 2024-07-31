using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class Platform
{
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("project_count")]
    public int ProjectCount { get; set; }
    public string HomePage { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    [JsonPropertyName("default_language")]
    public string DefaultLanguage { get; set; } = string.Empty;
}
