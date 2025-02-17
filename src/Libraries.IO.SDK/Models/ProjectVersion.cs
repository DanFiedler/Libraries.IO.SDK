using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class ProjectVersion
{
    public string Number { get; set; } = string.Empty;

    [JsonPropertyName("published_at")]
    public string PublishedAt { get; set; } = string.Empty;

    [JsonPropertyName("spdx_expression")]
    public string SpdxExpression { get; set; } = string.Empty;

    [JsonPropertyName("original_license")]
    public object OriginalLicense { get; set; } = string.Empty;

    [JsonPropertyName("researched_at")]
    public object ResearchedAt { get; set; } = string.Empty;

    [JsonPropertyName("repository_sources")]
    public List<string> RepositorySources { get; set; } = [];
}
