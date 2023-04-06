using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly.Extensions.Http;
using Polly;
using SumoPoolManager;
using System.Text.Json;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWebScrapper, WebScrapper>();
        services.AddHttpClient("SumoBasho").SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(GetRetryPolicy());
    })
    .Build();
using var poolStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "Pool202301.json"));
var pool = await JsonSerializer.DeserializeAsync<Pool>(poolStream);
var webScrapper = host.Services.GetService<IWebScrapper>();

if (webScrapper == null)
    return;

var results = await webScrapper.GetBashoResults("202301", 1);
Console.Write(results);
await host.RunAsync();

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                    retryAttempt)));
}