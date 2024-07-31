namespace Libraries.IO.SDK;

public class ProjectSortType(string value)
{
    private readonly string _value = value;
    private static readonly ProjectSortType _none = new("rank");
    public static ProjectSortType None { get { return _none; } }
    public static ProjectSortType Rank { get { return new ProjectSortType("rank"); } }
    public static ProjectSortType Stars { get { return new ProjectSortType("stars"); } }
    public static ProjectSortType DependentsCount { get { return new ProjectSortType("dependents_count"); } }
    public static ProjectSortType DependentReposCount { get { return new ProjectSortType("dependent_repos_count"); } }
    public static ProjectSortType LatestReleasePublishedAt { get { return new ProjectSortType("latest_release_published_at"); } }
    public static ProjectSortType ContributionsCount { get { return new ProjectSortType("contributions_count"); } }
    public static ProjectSortType CreatedAt { get { return new ProjectSortType("created_at"); } }

    public override string ToString()
    {
        return _value;
    }
}

public record ProjectSearchParameters
{
    public ProjectSortType Sort { get; set; } = ProjectSortType.None;
    public string Keywords { get; set; } = string.Empty;
    public string Languages { get; set; } = string.Empty;
    public string Licenses { get; set; } = string.Empty;
    public string Platforms { get; set; } = string.Empty;
}
