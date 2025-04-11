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
        await foreach(var platform in client.GetPlatforms(cts.Token))
        {
            Console.WriteLine($"Platform: {platform.Name}");
        }

        Console.WriteLine("Sample project search for `grunt`:");
        var searchParameters = new ProjectSearchParameters
        {
            Platforms = "npm"
        };
        var projects = await client.SearchProjectsSync("grunt", cts.Token, searchParameters);
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

        Console.WriteLine("Libraries.IO.SDK sample ConsoleApp completed.");
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
