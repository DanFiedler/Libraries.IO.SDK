# Libraries.IO.SDK

## Introduction

A C#/.NET API wrapper for the [Libraries.IO API](https://libraries.io/api).

**Libraries.IO.SDK** currently supports all of the Libraries.IO API endpoints EXCEPT `subscriptions`.

## Usage 

Add the [Libraries.IO.SDK Nuget package](https://www.nuget.org/packages/Fiedler.Libraries.IO.SDK) to your project
and use `ILibrariesIOClient` to call the desired endpoints. This package assumes usage of [.NET dependency injection](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
and requires registration of [IHttpClientFactory](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory).

Each `ILibrariesIOClient` method calls the corresponding Libraries.IO API and deserializes the JSON response into strongly typed objects.
(e.g., `GetProject` calls the `https://libraries.io/api/:platform/:name` endpoint.) Each method's documentation comments include the 
method's associated endpoint.

Basic usage is demonstrated in the `samples\Libraries.IO.SDK.Sample` project and in the code block below:

```csharp
    // Sample DI setup of ILibrariesIOClient
    var builder = Host.CreateApplicationBuilder(args);    
    var config = new ClientConfiguration
    {
        ApiKey = Environment.GetEnvironmentVariable("LIBRARIES_IO_API_KEY") ?? string.Empty,
    };
    builder.Services.AddSingleton(config);
    builder.Services.AddHttpClient();
    builder.Services.AddSingleton<ILibrariesIOClient, LibrariesIOClient>();
    var host = builder.Build();

    // Sample usage of ILibrariesIOClient to get list of platforms from LibrariesIO
    var client = host.Services.GetRequiredService<ILibrariesIOClient>();
    var cts = new CancellationTokenSource();
    await foreach(var platform in client.GetPlatforms(cts.Token))
    {
        Console.WriteLine($"Platform: {platform.Name}");
    }
```

If desired, behavior of the `HttpClient` used by `ILibrariesIOClient` can be customized 
using a [named client](https://learn.microsoft.com/en-us/dotnet/core/extensions/httpclient-factory#named-clients) and setting `ClientConfiguration.HttpClientName`.

## Build and Test

**Libraries.IO.SDK** targets [.NET 8.0](https://dotnet.microsoft.com/en-us/download) and can be built and tested using standard commands.

- Build: `dotnet build`
- Run Tests: `dotnet test`

## Contribute

Please feel free to send pull requests and raise issues 
(but first do a search of open issues to see if someone has already filed a similar request).

## Security

See [SECURITY](SECURITY.md).

## License

**Libraries.IO.SDK** is licensed under the [MIT](LICENSE.TXT) license.
