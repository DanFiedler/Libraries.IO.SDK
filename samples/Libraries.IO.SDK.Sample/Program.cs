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
