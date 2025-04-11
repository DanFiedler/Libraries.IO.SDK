using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Libraries.IO.SDK.Sample;

public class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Libraries.IO.SDK sample ConsoleApp starting...");

        var host = CreateApplicationHost(args);
        var client = host.Services.GetRequiredService<ILibrariesIOClient>();

        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;
        await GetAndPrintPlatforms(client, cancellationToken);
        await GetAndPrintSearchResults(client, cancellationToken);

        Console.WriteLine("Libraries.IO.SDK sample ConsoleApp completed.");
    }

    private static async Task GetAndPrintPlatforms(ILibrariesIOClient client, CancellationToken cancellationToken)
    {
        var platforms = await client.GetPlatforms(cancellationToken);
        if (platforms != null)
        {
            foreach (var platform in platforms)
            {
                Console.WriteLine($"Platform: {platform.Name}");
            }
        }
    }

    private static async Task GetAndPrintSearchResults(ILibrariesIOClient client, CancellationToken cancellationToken)
    {
        Console.WriteLine("Sample project search for `grunt`:");
        var searchParameters = new ProjectSearchParameters
        {
            Platforms = "npm"
        };
        var projects = await client.SearchProjects("grunt", cancellationToken, searchParameters);
        if (projects == null)
        {
            Console.WriteLine("No projects found.");
        }
        else
        {
            for (int i = 0; i < projects.Length; i++)
            {
                var project = projects[i];
                Console.WriteLine($"Project {i + 1} Name:{project.Name}, LatestRelease:{project.LatestReleaseNumber}, VersionCount:{project.Versions.Count}");
            }
        }
    }

    private static IHost CreateApplicationHost(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        ConfigureServices(builder);
        return builder.Build();
    }

    private static void ConfigureServices(HostApplicationBuilder builder)
    {
        LoggerFactory.Create(loggingBuilder =>
        {
            loggingBuilder.AddConsole();
        });
        builder.Services.AddHttpClient();
        builder.Services.AddSingleton<ILibrariesIOClient, LibrariesIOClient>();
    }
}
