using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SumoPoolManager;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWebScrapper, WebScrapper>();
        services.AddHttpClient();
    })
    .Build();

var webScrapper = host.Services.GetService<IWebScrapper>();
var results = await webScrapper.GetBashoResults("202301",15);
Console.Write(results);
await host.RunAsync();