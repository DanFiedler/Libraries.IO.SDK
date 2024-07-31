using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class Project
{
    [JsonPropertyName("code_of_conduct_url")]
    public string CodeOfConductUrl { get; set; } = string.Empty;

    [JsonPropertyName("contributions_count")]
    public int ContributionsCount { get; set; }

    [JsonPropertyName("contribution_guidelines_url")]
    public string ContributionGuidelinesUrl { get; set; } = string.Empty;

    [JsonPropertyName("dependent_repos_count")]
    public int DependentReposCount { get; set; }

    [JsonPropertyName("dependents_count")]
    public int DependentsCount { get; set; }

    [JsonPropertyName("deprecation_reason")]
    public string DeprecationReason { get; set; } = string.Empty;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("forks")]
    public int Forks { get; set; }

    [JsonPropertyName("funding_urls")]
    public List<string> FundingUrls { get; set; } = [];

    [JsonPropertyName("homepage")]
    public string Homepage { get; set; } = string.Empty;

    [JsonPropertyName("keywords")]
    public List<string> Keywords { get; set; } = [];

    [JsonPropertyName("language")]
    public string Language { get; set; } = string.Empty;

    [JsonPropertyName("latest_download_url")]
    public string LatestDownloadUrl { get; set; } = string.Empty;

    [JsonPropertyName("latest_release_number")]
    public string LatestReleaseNumber { get; set; } = string.Empty;

    [JsonPropertyName("latest_release_published_at")]
    public string LatestReleasePublishedAt { get; set; } = string.Empty;

    [JsonPropertyName("latest_stable_release_number")]
    public string LatestStableReleaseNumber { get; set; } = string.Empty;

    [JsonPropertyName("latest_stable_release_published_at")]
    public string LatestStableReleasePublishedAt { get; set; } = string.Empty;

    [JsonPropertyName("license_normalized")]
    public bool LicenseNormalized { get; set; }

    [JsonPropertyName("licenses")]
    public string Licenses { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("normalized_licenses")]
    public List<string> NormalizedLicenses { get; set; } = [];

    [JsonPropertyName("package_manager_url")]
    public string PackageManagerUrl { get; set; } = string.Empty;

    [JsonPropertyName("platform")]
    public string Platform { get; set; } = string.Empty;

    [JsonPropertyName("rank")]
    public int Rank { get; set; }

    [JsonPropertyName("repository_license")]
    public string RepositoryLicense { get; set; } = string.Empty;

    [JsonPropertyName("repository_status")]
    public string RepositoryStatus { get; set; } = string.Empty;

    [JsonPropertyName("repository_url")]
    public string RepositoryUrl { get; set; } = string.Empty;

    [JsonPropertyName("security_policy_url")]
    public string SecurityPolicyUrl { get; set; } = string.Empty;

    [JsonPropertyName("stars")]
    public int Stars { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; } = string.Empty;

    [JsonPropertyName("versions")]
    public List<ProjectVersion> Versions { get; set; } = [];

    [JsonPropertyName("dependencies_for_version")]
    public string DependenciesForVersion { get; set; } = string.Empty;

    // Dependencies is only populated when calling the Project Dependencies API
    public List<Dependency> Dependencies { get; set; } = [];
}
