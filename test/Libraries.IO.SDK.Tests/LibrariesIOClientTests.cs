using FluentAssertions;
using NSubstitute;

namespace Libraries.IO.SDK.Tests;

public class LibrariesIOClientTests
{
    [Fact]
    public async Task When_GetPlatforms_called_then_name_matches_expected()
    {
        string json = GetJson("platform.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var platforms = await client.GetPlatforms(CancellationToken.None).ToListAsync();

        var platform = platforms.FirstOrDefault();
        Assert.NotNull(platform);
        platform.Name.Should().Be("NPM");
    }

    [Fact]
    public async Task When_GetProject_called_then_description_matches_expected()
    {
        string json = GetJson("project.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var project = await client.GetProject("NPM", "arbitrary", CancellationToken.None);

        Assert.NotNull(project);
        project.Description.Should().Be("JavaScript Base62 encode/decoder");
    }

    [Fact]
    public async Task When_GetProject_called_then_request_uri_matches_expected()
    {
        string json = GetJson("project.json");
        var messageHandler = new FakeHttpMessageHandler(json);
        var httpClientFactory = SetupHttpClientFactory(messageHandler);
        var client = CreateClient(httpClientFactory);

        var project = await client.GetProject("npm", "arbitrary", CancellationToken.None);

        Assert.NotNull(project);
        Assert.NotNull(messageHandler.LastRequestUri);
        string url = messageHandler.LastRequestUri.AbsoluteUri;
        url.Should().Be("https://libraries.io/api/npm/arbitrary?api_key=MyApiKey");
    }

    [Fact]
    public async Task When_GetProjectDependencies_called_then_dependency_count_is_two()
    {
        string json = GetJson("project_dependencies.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var project = await client.GetProjectDependencies("NuGet", "BenchmarkDotNet", "latest", CancellationToken.None);

        Assert.NotNull(project);
        project.Dependencies.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetProjectDependents_then_number_of_projects_is_two()
    {
        string json = GetJson("project_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var projects = await client.GetProjectDependents("NuGet", "BenchmarkDotNet", CancellationToken.None).ToListAsync();

        Assert.NotNull(projects);
        projects.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetProjectDependentRepositories_called_then_count_is_two()
    {
        string json = GetJson("repository_array.json"); ;
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repositories = await client.GetProjectDependentRepositories("NuGet", "BenchmarkDotNet", CancellationToken.None).ToListAsync();

        Assert.NotNull(repositories);
        repositories.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetProjectContributors_called_then_count_is_two()
    {
        string json = GetJson("contributor_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var contributors = await client.GetProjectContributors("arbitraryPlatform", "arbitraryProject", CancellationToken.None).ToListAsync();

        Assert.NotNull(contributors);
        contributors.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetProjectSourceRank_called_then_basic_info_matches_expected()
    {
        string json = GetJson("source_rank.json");

        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var sourceRank = await client.GetProjectSourceRank("arbitraryPlatform", "arbitraryProject", CancellationToken.None);

        Assert.NotNull(sourceRank);
        sourceRank.BasicInfoPresent.Should().Be(1);
    }

    [Fact]
    public async Task When_SearchProjects_called_then_count_is_two()
    {
        string json = GetJson("project_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var projects = await client.SearchProjects(null, CancellationToken.None).ToListAsync();

        Assert.NotNull(projects);
        projects.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetRepository_called_then_full_name_matches_expected()
    {
        string json = GetJson("repository.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repository = await client.GetRepository("arbitraryOwner", "arbitraryProject", CancellationToken.None);

        Assert.NotNull(repository);
        repository.FullName.Should().Be("gruntjs/grunt");
    }

    [Fact]
    public async Task When_GetRepositoryDependencies_called_then_count_is_three()
    {
        string json = GetJson("repository_dependencies.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repository = await client.GetRepositoryDependencies("arbitraryOwner", "arbitraryProject", CancellationToken.None);

        Assert.NotNull(repository);
        repository.FullName.Should().Be("gruntjs/grunt");
        repository.Dependencies.Count.Should().Be(3);
    }

    [Fact]
    public async Task When_GetRepositoryProjects_called_then_count_is_two()
    {
        string json = GetJson("project_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var projects = await client.GetRepositoryProjects("arbitraryOwner", "arbitraryProject", CancellationToken.None).ToListAsync();

        Assert.NotNull(projects);
        projects.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetUser_called_then_name_matches_expected()
    {
        string json = GetJson("user.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var user = await client.GetUser("arbitraryLogin", CancellationToken.None);

        Assert.NotNull(user);
        user.Name.Should().Be("Dan Fiedler");
    }

    [Fact]
    public async Task When_GetUserRepositories_called_then_count_is_two()
    {
        string json = GetJson("repository_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repositories = await client.GetUserRepositories("arbitraryLogin", CancellationToken.None).ToListAsync();

        Assert.NotNull(repositories);
        repositories.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetUserProjects_called_then_count_is_two()
    {
        string json = GetJson("project_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repositories = await client.GetUserProjects("arbitraryLogin", CancellationToken.None).ToListAsync();

        Assert.NotNull(repositories);
        repositories.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetUserPackageContributions_called_then_count_is_two()
    {
        string json = GetJson("project_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repositories = await client.GetUserPackageContributions("arbitraryLogin", CancellationToken.None).ToListAsync();

        Assert.NotNull(repositories);
        repositories.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetUserRepositoryContributions_called_then_count_is_two()
    {
        string json = GetJson("repository_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repositories = await client.GetUserRepositoryContributions("arbitraryLogin", CancellationToken.None).ToListAsync();

        Assert.NotNull(repositories);
        repositories.Count.Should().Be(2);
    }

    [Fact]
    public async Task When_GetUserDependencies_called_then_count_is_two()
    {
        string json = GetJson("project_array.json");
        var httpClientFactory = SetupHttpClientFactory(json);
        var client = CreateClient(httpClientFactory);

        var repositories = await client.GetUserDependencies("arbitraryLogin", CancellationToken.None).ToListAsync();

        Assert.NotNull(repositories);
        repositories.Count.Should().Be(2);
    }

    private static string GetJson(string resourceName)
    {
        string resourcePath = $"Libraries.IO.SDK.Tests.Resources.{resourceName}";
        var assembly = typeof(LibrariesIOClientTests).Assembly;
        using var stream = assembly.GetManifestResourceStream(resourcePath);
        Assert.NotNull(stream);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    private static LibrariesIOClient CreateClient(IHttpClientFactory httpClientFactory)
    {
        return new LibrariesIOClient(httpClientFactory, new ClientConfiguration
        {
            ApiKey = "MyApiKey"
        });
    }

    private static IHttpClientFactory SetupHttpClientFactory(string json)
    {
        var httpMessageHandler = new FakeHttpMessageHandler(json);
        var httpClient = new HttpClient(httpMessageHandler);
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        return httpClientFactory;
    }

    private static IHttpClientFactory SetupHttpClientFactory(FakeHttpMessageHandler httpMessageHandler)
    {
        var httpClient = new HttpClient(httpMessageHandler);
        var httpClientFactory = Substitute.For<IHttpClientFactory>();
        httpClientFactory.CreateClient(Arg.Any<string>()).Returns(httpClient);
        return httpClientFactory;
    }
}