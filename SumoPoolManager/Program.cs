using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SumoPoolManager;
using System.Text.Json;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWebScrapper, WebScrapper>();
        services.AddHttpClient();
    })
    .Build();
using var poolStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "Pool202301.json"));
var pool = await JsonSerializer.DeserializeAsync<Pool>(poolStream);
var webScrapper = host.Services.GetService<IWebScrapper>();
var results = await webScrapper.GetBashoResults("202301",1);
Console.Write(results);
await host.RunAsync();