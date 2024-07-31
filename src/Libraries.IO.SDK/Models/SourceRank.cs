using System.Text.Json.Serialization;

namespace Libraries.IO.SDK.Models;
public class SourceRank
{
    [JsonPropertyName("basic_info_present")]
    public int BasicInfoPresent { get; set; }

    [JsonPropertyName("repository_present")]
    public int RepositoryPresent { get; set; }

    [JsonPropertyName("readme_present")]
    public int ReadmePresent { get; set; }

    [JsonPropertyName("license_present")]
    public int LicensePresent { get; set; }

    [JsonPropertyName("versions_present")]
    public int VersionsPresent { get; set; }

    [JsonPropertyName("follows_semver")]
    public int FollowsSemver { get; set; }

    [JsonPropertyName("recent_release")]
    public int RecentRelease { get; set; }

    [JsonPropertyName("not_brand_new")]
    public int NotBrandNew { get; set; }

    [JsonPropertyName("one_point_oh")]
    public int OnePointOh { get; set; }

    [JsonPropertyName("dependent_projects")]
    public int DependentProjects { get; set; }

    [JsonPropertyName("dependent_repositories")]
    public int DependentRepositories { get; set; }

    public int Stars { get; set; }

    public int Contributors { get; set; }

    public int Subscribers { get; set; }

    [JsonPropertyName("all_prereleases")]
    public int AllPrereleases { get; set; }

    [JsonPropertyName("any_outdated_dependencies")]
    public int AnyOutdatedDependencies { get; set; }

    [JsonPropertyName("is_deprecated")]
    public int IsDeprecated { get; set; }

    [JsonPropertyName("is_unmaintained")]
    public int IsUnmaintained { get; set; }

    [JsonPropertyName("is_removed")]
    public int IsRemoved { get; set; }
}
