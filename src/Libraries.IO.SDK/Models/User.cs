using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class User
{
    public int Id { get; set; }
    public string Uuid { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;

    [JsonPropertyName("user_type")]
    public string UserType { get; set; } = string.Empty;

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Blog { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public bool Hidden { get; set; }

    [JsonPropertyName("last_synced_at")]
    public DateTime LastSyncedAt { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public int Followers { get; set; }
    public int Following { get; set; }

    [JsonPropertyName("host_type")]
    public string HostType { get; set; } = string.Empty;
}
