using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class Repository
{
    [JsonPropertyName("full_name")]
    public string FullName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Fork { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }

    [JsonPropertyName("pushed_at")]
    public DateTime PushedAt { get; set; }

    public string HomePage { get; set; } = string.Empty;
    public int Size { get; set; }

    [JsonPropertyName("stargazers_count")]
    public int StargazersCount { get; set; }
    public string Language { get; set; } = string.Empty;

    [JsonPropertyName("has_issues")]
    public bool HasIssues { get; set; }

    [JsonPropertyName("has_wiki")]
    public bool HasWiki { get; set; }

    [JsonPropertyName("has_pages")]
    public bool HasPages { get; set; }

    [JsonPropertyName("forks_count")]
    public int ForksCount { get; set; }

    [JsonPropertyName("mirror_url")]
    public string MirrorUrl { get; set; } = string.Empty;

    [JsonPropertyName("open_issues_count")]
    public int OpenIssuesCount { get; set; }

    [JsonPropertyName("default_branch")]
    public string DefaultBranch { get; set; } = string.Empty;

    [JsonPropertyName("subscribers_count")]
    public int SubscribersCount { get; set; }

    public string Uuid { get; set; } = string.Empty;

    [JsonPropertyName("source_name")]
    public string SourceName { get; set; } = string.Empty;
    public string License { get; set; } = string.Empty;
    public bool Private { get; set; }

    [JsonPropertyName("contributions_count")]
    public int ContributionsCount { get; set; }

    [JsonPropertyName("has_readme")]
    public string HasReadme { get; set; } = string.Empty;

    [JsonPropertyName("has_changelog")]
    public string HasChangelog { get; set; } = string.Empty;

    [JsonPropertyName("has_contributing")]
    public string HasContributing { get; set; } = string.Empty;

    [JsonPropertyName("has_license")]
    public string HasLicense { get; set; } = string.Empty;

    [JsonPropertyName("has_coc")]
    public string HasCoc { get; set; } = string.Empty;

    [JsonPropertyName("has_threat_model")]
    public object HasThreatModel { get; set; } = string.Empty;

    [JsonPropertyName("has_audit")]
    public object HasAudit { get; set; } = string.Empty;

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("last_synced_at")]
    public DateTime LastSyncedAt { get; set; }

    public int Rank { get; set; }

    [JsonPropertyName("host_type")]
    public string HostType { get; set; } = string.Empty;

    [JsonPropertyName("host_domain")]
    public string HostDomain { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Scm { get; set; } = string.Empty;

    [JsonPropertyName("fork_policy")]
    public object ForkPolicy { get; set; } = string.Empty;

    [JsonPropertyName("pull_requests_enabled")]
    public object PullRequestsEnabled { get; set; } = string.Empty;

    [JsonPropertyName("logo_url")]
    public object LogoUrl { get; set; } = string.Empty;

    public List<string> Keywords { get; set; } = [];

    [JsonPropertyName("maintenance_stats_refreshed_at")]
    public DateTime MaintenanceStatsRefreshedAt { get; set; }

    [JsonPropertyName("code_of_conduct_url")]
    public string CodeOfConductUrl { get; set; } = string.Empty;

    [JsonPropertyName("contribution_guidelines_url")]
    public string ContributionGuidelinesUrl { get; set; } = string.Empty;

    [JsonPropertyName("security_policy_url")]
    public string SecurityPolicyUrl { get; set; } = string.Empty;

    [JsonPropertyName("funding_urls")]
    public List<string> FundingUrls { get; set; } = [];

    [JsonPropertyName("github_contributions_count")]
    public int GithubContributionsCount { get; set; }

    [JsonPropertyName("github_id")]
    public string GitHubId { get; set; } = string.Empty;

    // Dependencies is only populated when calling the Repository Dependencies API
    public List<Dependency> Dependencies { get; set; } = [];
}
