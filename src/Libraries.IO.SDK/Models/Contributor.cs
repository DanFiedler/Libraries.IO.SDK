using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class Contributor
{
    [JsonPropertyName("github_id")]
    public string GitHubId { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;

    [JsonPropertyName("user_type")]
    public string UserType { get; set; } = string.Empty;

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; } = string.Empty;

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Blog { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool Hidden { get; set; } 

    [JsonPropertyName("last_synced_at")]
    public string LastSyncedAt { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string Uuid { get; set; } = string.Empty;

    [JsonPropertyName("host_type")]
    public string HostType { get; set; } = string.Empty;
}
