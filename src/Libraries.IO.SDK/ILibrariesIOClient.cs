using Libraries.IO.SDK.Models;

namespace Libraries.IO.SDK;
public interface ILibrariesIOClient
{
    /// <summary>
    /// Get a list of supported package managers.
    /// GET https://libraries.io/api/platforms
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Platform[]?> GetPlatforms(CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get information about a package and its versions.
    /// GET https://libraries.io/api/:platform/:name
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="project"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Project?> GetProject(string platform, string project, CancellationToken cancellationToken);

    /// <summary>
    /// Get packages that have at least one version that depends on a given project.
    /// GET https://libraries.io/api/:platform/:name/:version/dependencies
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="project"></param>
    /// <param name="version"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Project?> GetProjectDependencies(string platform, string project, string version, CancellationToken cancellationToken);

    /// <summary>
    /// Get packages that have at least one version that depends on a given project.
    /// NOTE - at time of writing this endpoint was disabled for performance purposes.
    /// GET https://libraries.io/api/:platform/:name/dependents
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Project[]?> GetProjectDependents(string platform, string name, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get repositories that depend on a given project.
    /// GET https://libraries.io/api/:platform/:name/dependent_repositories
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Repository[]?> GetProjectDependentRepositories(string platform, string name, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get users that have contributed to a given project.
    /// GET https://libraries.io/api/:platform/:name/contributors
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Contributor[]?> GetProjectContributors(string platform, string name, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get breakdown of SourceRank score for a given project.
    /// https://libraries.io/api/:platform/:name/sourcerank
    /// </summary>
    /// <param name="platform"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<SourceRank?> GetProjectSourceRank(string platform, string name, CancellationToken cancellationToken);

    /// <summary>
    /// Search for projects.
    /// GET https://libraries.io/api/search?q=
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="searchParameters"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Project[]?> SearchProjects(string? query, CancellationToken cancellationToken, ProjectSearchParameters? searchParameters = null, int page = 1, int perPage = 30);

    /// <summary>
    /// Get info for a repository. Currently only works for open source repositories.
    /// GET https://libraries.io/api/github/:owner/:name
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Repository?> GetRepository(string owner, string name, CancellationToken cancellationToken);

    /// <summary>
    /// Get a repository with a list of dependencies for all of a repository's projects. Currently only works for open source repositories.
    /// GET https://libraries.io/api/github/:owner/:name/dependencies
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<Repository?> GetRepositoryDependencies(string owner, string name, CancellationToken cancellationToken);

    /// <summary>
    /// Get a list of packages referencing the given repository.
    /// GET https://libraries.io/api/github/:owner/:name/projects
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Project[]?> GetRepositoryProjects(string owner, string name, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get information for a given user or organization.
    /// GET https://libraries.io/api/github/:login
    /// </summary>
    /// <param name="login"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<User?> GetUser(string login, CancellationToken cancellationToken);

    /// <summary>
    /// Get repositories owned by a user.
    /// GET https://libraries.io/api/github/:login/repositories
    /// </summary>
    /// <param name="login"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Repository[]?> GetUserRepositories(string login, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get a list of packages referencing the given user's repositories.
    /// GET https://libraries.io/api/github/:login/projects
    /// </summary>
    /// <param name="login"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Project[]?> GetUserProjects(string login, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get a list of packages that the given user has contributed to.
    /// GET https://libraries.io/api/github/:login/project-contributions
    /// </summary>
    /// <param name="login"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Project[]?> GetUserPackageContributions(string login, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get a list of repositories that the given user has contributed to.
    /// GET https://libraries.io/api/github/:login/repository-contributions
    /// </summary>
    /// <param name="login"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Repository[]?> GetUserRepositoryContributions(string login, CancellationToken cancellationToken, int page = 1, int perPage = 30);

    /// <summary>
    /// Get a list of unique packages that the given user's repositories list as a dependency. Ordered by frequency of use in those repositories.
    /// GET https://libraries.io/api/github/:login/dependencies
    /// </summary>
    /// <param name="login"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="platform"></param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <returns></returns>
    public Task<Project[]?> GetUserDependencies(string login, CancellationToken cancellationToken, string? platform = null, int page = 1, int perPage = 30);
}
