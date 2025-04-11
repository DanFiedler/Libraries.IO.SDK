using Libraries.IO.SDK.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;

namespace Libraries.IO.SDK;

public class LibrariesIOClient : ILibrariesIOClient
{
    public static class ConfigurationKeys
    {
        public const string ApiKey = "LIBRARIES_IO_API_KEY";
    }

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _apiKey;

    public LibrariesIOClient(IHttpClientFactory httpClientFactory, IConfiguration config)
    {
        _httpClientFactory = httpClientFactory;
        string? apiKey = config[ConfigurationKeys.ApiKey] ?? throw new InvalidOperationException($"LibrariesIOClient requires configuration '{ConfigurationKeys.ApiKey}' to be set.");
        _apiKey = apiKey;
    }

    public async IAsyncEnumerable<Platform> GetPlatforms([EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        string url = $"https://libraries.io/api/platforms?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var platforms = httpClient.GetFromJsonAsAsyncEnumerable<Platform>(url, cancellationToken);
        await foreach(var platform in platforms)
        {
            if (platform != null)
            {
                yield return platform;
            }
        }
    }

    public Task<Project?> GetProject(string platform, string project, CancellationToken cancellationToken)
    {
        string url = $"https://libraries.io/api/{platform}/{project}?api_key={_apiKey}";
        var httpClient = _httpClientFactory.CreateClient();
        return httpClient.GetFromJsonAsync<Project>(url, cancellationToken);
    }

    public Task<Project?> GetProjectDependencies(string platform, string name, string version, CancellationToken cancellationToken)
    {
        platform = UrlEncoder.Default.Encode(platform);
        name = UrlEncoder.Default.Encode(name);
        version = UrlEncoder.Default.Encode(version);
        string url = $"https://libraries.io/api/{platform}/{name}/{version}/dependencies?api_key={_apiKey}";
        var httpClient = _httpClientFactory.CreateClient();
        return httpClient.GetFromJsonAsync<Project?>(url, cancellationToken);
    }

    public async IAsyncEnumerable<Project> GetProjectDependents(string platform, string name, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        platform = UrlEncoder.Default.Encode(platform);
        name = UrlEncoder.Default.Encode(name);
        string url = $"https://libraries.io/api/{platform}/{name}/dependents?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var projects = httpClient.GetFromJsonAsAsyncEnumerable<Project?>(url, cancellationToken);
        await foreach(var project in projects)
        {
            if (project != null)
            {
                yield return project;
            }
        }
    }

    public async IAsyncEnumerable<Repository> GetProjectDependentRepositories(string platform, string name, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        platform = UrlEncoder.Default.Encode(platform);
        name = UrlEncoder.Default.Encode(name);
        string url = $"https://libraries.io/api/{platform}/{name}/dependent_repositories?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var repositories = httpClient.GetFromJsonAsAsyncEnumerable<Repository?>(url, cancellationToken);
        await foreach (var repository in repositories)
        {
            if (repository != null)
            {
                yield return repository;
            }
        }
    }
    public async IAsyncEnumerable<Contributor> GetProjectContributors(string platform, string name, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        platform = UrlEncoder.Default.Encode(platform);
        name = UrlEncoder.Default.Encode(name);
        string url = $"https://libraries.io/api/{platform}/{name}/contributors?{GetCommonParameters(page,perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var contributors = httpClient.GetFromJsonAsAsyncEnumerable<Contributor?>(url, cancellationToken);
        await foreach (var contributor in contributors)
        {
            if (contributor != null)
            {
                yield return contributor;
            }
        }
    }

    public Task<SourceRank?> GetProjectSourceRank(string platform, string name, CancellationToken cancellationToken)
    {
        platform = UrlEncoder.Default.Encode(platform);
        name = UrlEncoder.Default.Encode(name);
        string url = $"https://libraries.io/api/{platform}/{name}/sourcerank?api_key={_apiKey}";
        var httpClient = _httpClientFactory.CreateClient();
        return httpClient.GetFromJsonAsync<SourceRank?>(url, cancellationToken);
    }

    public async Task<Project[]?> SearchProjectsSync(string? query, CancellationToken cancellationToken, ProjectSearchParameters? searchParameters = null, int page = 1, int perPage = 30)
    {
        string url = $"{ProjectSearchUrlBuilder.Build(query, searchParameters)}&{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var projects = await httpClient.GetFromJsonAsync<Project[]>(url, cancellationToken);
        return projects;
    }

    public async IAsyncEnumerable<Project> SearchProjects(string? query, [EnumeratorCancellation] CancellationToken cancellationToken, ProjectSearchParameters? searchParameters = null, int page = 1, int perPage = 30)
    {
        string url = $"{ProjectSearchUrlBuilder.Build(query, searchParameters)}&{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var projects = httpClient.GetFromJsonAsAsyncEnumerable<Project?>(url, cancellationToken);
        await foreach (var project in projects)
        {
            if (project != null)
            {
                yield return project;
            }
        }
    }

    public Task<Repository?> GetRepository(string owner, string name, CancellationToken cancellationToken)
    {
        owner = UrlEncoder.Default.Encode(owner);
        name = UrlEncoder.Default.Encode(name);
        string url = $"https://libraries.io/api/github/{owner}/{name}?api_key={_apiKey}";
        var httpClient = _httpClientFactory.CreateClient();
        return httpClient.GetFromJsonAsync<Repository?>(url, cancellationToken);
    }

    public Task<Repository?> GetRepositoryDependencies(string owner, string name, CancellationToken cancellationToken)
    {
        owner = UrlEncoder.Default.Encode(owner);
        name = UrlEncoder.Default.Encode(name);
        string url = $"https://libraries.io/api/github/{owner}/{name}/dependencies?api_key={_apiKey}";
        var httpClient = _httpClientFactory.CreateClient();
        return httpClient.GetFromJsonAsync<Repository?>(url, cancellationToken);
    }

    public async IAsyncEnumerable<Project> GetRepositoryProjects(string owner, string name, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        // GET https://libraries.io/api/github/:owner/:name/projects?api_key=YOUR_API_KEY
        owner = UrlEncoder.Default.Encode(owner);
        name = UrlEncoder.Default.Encode(name);
        string url = $"https://libraries.io/api/github/{owner}/{name}/projects?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var projects = httpClient.GetFromJsonAsAsyncEnumerable<Project?>(url, cancellationToken);
        await foreach (var project in projects)
        {
            if (project != null)
            {
                yield return project;
            }
        }
    }

    public Task<User?> GetUser(string login, CancellationToken cancellationToken)
    {
        login = UrlEncoder.Default.Encode(login);
        string url = $"https://libraries.io/api/github/{login}?api_key={_apiKey}";
        var httpClient = _httpClientFactory.CreateClient();
        return httpClient.GetFromJsonAsync<User?>(url, cancellationToken);
    }

    public async IAsyncEnumerable<Repository> GetUserRepositories(string login, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        login = UrlEncoder.Default.Encode(login);
        string url = $"https://libraries.io/api/github/{login}/repositories?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var repositories = httpClient.GetFromJsonAsAsyncEnumerable<Repository?>(url, cancellationToken);
        await foreach (var repository in repositories)
        {
            if (repository != null)
            {
                yield return repository;
            }
        }
    }

    public async IAsyncEnumerable<Project> GetUserProjects(string login, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        login = UrlEncoder.Default.Encode(login);
        string url = $"https://libraries.io/api/github/{login}/projects?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var projects = httpClient.GetFromJsonAsAsyncEnumerable<Project?>(url, cancellationToken);
        await foreach (var project in projects)
        {
            if (project != null)
            {
                yield return project;
            }
        }
    }

    public async IAsyncEnumerable<Project> GetUserPackageContributions(string login, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        login = UrlEncoder.Default.Encode(login);
        string url = $"https://libraries.io/api/github/{login}/project-contributions?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var projects = httpClient.GetFromJsonAsAsyncEnumerable<Project?>(url, cancellationToken);
        await foreach (var project in projects)
        {
            if (project != null)
            {
                yield return project;
            }
        }
    }

    public async IAsyncEnumerable<Repository> GetUserRepositoryContributions(string login, [EnumeratorCancellation] CancellationToken cancellationToken, int page = 1, int perPage = 30)
    {
        login = UrlEncoder.Default.Encode(login);
        string url = $"https://libraries.io/api/github/{login}/repository-contributions?{GetCommonParameters(page, perPage)}";
        var httpClient = _httpClientFactory.CreateClient();
        var repositories = httpClient.GetFromJsonAsAsyncEnumerable<Repository?>(url, cancellationToken);
        await foreach (var repository in repositories)
        {
            if (repository != null)
            {
                yield return repository;
            }
        }
    }

    public async IAsyncEnumerable<Project> GetUserDependencies(string login, [EnumeratorCancellation] CancellationToken cancellationToken, string? platform = null, int page = 1, int perPage = 30)
    {
        string url = $"https://libraries.io/api/github/{login}/dependencies?{GetCommonParameters(page, perPage)}";
        if (!string.IsNullOrEmpty(platform))
        {
            platform = UrlEncoder.Default.Encode(platform);
            url += $"&platform={platform}";
        }
        var httpClient = _httpClientFactory.CreateClient();
        var projects = httpClient.GetFromJsonAsAsyncEnumerable<Project?>(url, cancellationToken);
        await foreach (var project in projects)
        {
            if (project != null)
            {
                yield return project;
            }
        }
    }

    private string GetCommonParameters(int page, int perPage)
    {
        return $"api_key={_apiKey}&page={page}&per_page={perPage}";
    }
}
