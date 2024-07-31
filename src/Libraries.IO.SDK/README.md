# Libraries.IO.SDK

This package is a client library API wrapper for the [Libraries.IO API](https://libraries.io/api).

**Libraries.IO.SDK** currently supports all of the current Libraries.IO API endpoints EXCEPT the `subscriptions` endpoints.

## Usage

Use `ILibrariesIOClient` to call the desired endpoints. This package assumes usage of [.NET dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
and requires registration of [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory).

The `ILibrariesIOClient` class provides methods for each endpoint of the Libraries.IO API.
Each `ILibrariesIOClient` method calls the corresponding Libraries.IO API and deserializes the JSON response into strongly typed objects.

```csharp
    // Sample DI setup of ILibrariesIOClient
    var builder = Host.CreateApplicationBuilder(args);
    ConfigureServices(builder);
    var host = builder.Build();
    var config = new ClientConfiguration
    {
        ApiKey = Environment.GetEnvironmentVariable("LIBRARIES_IO_API_KEY") ?? string.Empty,
    };
    builder.Services.AddSingleton(config);
    builder.Services.AddHttpClient();
    builder.Services.AddSingleton<ILibrariesIOClient, LibrariesIOClient>();
    var client = host.Services.GetRequiredService<ILibrariesIOClient>();

    // Sample usage of ILibrariesIOClient to get list of platforms from LibrariesIO
    var cts = new CancellationTokenSource();
    await foreach(var platform in client.GetPlatforms(cts.Token))
    {
        Console.WriteLine($"Platform: {platform.Name}");
    }
```

If desired, behavior of the `HttpClient` used by `ILibrariesIOClient` can be customized
using a [named client](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory#named-clients) and setting `ClientConfiguration.HttpClientName`.

# Documentation

For more information, please refer to the package's [GitHub repository](https://github.com/DanFiedler/Libraries.IO.SDK).