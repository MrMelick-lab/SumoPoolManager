using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly.Extensions.Http;
using Polly;
using SumoPoolManager;
using System.Text.Json;
using ConsoleTables;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IWebScrapper, WebScrapper>();
        services.AddScoped<IScoreCalculator, ScoreCalculator>();
        services.AddHttpClient("SumoBasho").SetHandlerLifetime(TimeSpan.FromMinutes(5)).AddPolicyHandler(GetRetryPolicy());
    })
    .ConfigureLogging((_, logging) =>
    {
        logging.ClearProviders();
        logging.AddSimpleConsole(options => options.IncludeScopes = true);
    })
    .Build();

var validator = new ArgsValidator();
var validationResult = validator.Validate(args);

if (validationResult.IsValid())
{
    using var poolStream = File.OpenRead(args[0]);
    var pool = await JsonSerializer.DeserializeAsync<Pool>(poolStream);
    var scoreCalculator = host.Services.GetService<IScoreCalculator>();
    if (scoreCalculator == null || pool == null)
        return;

    var results = await scoreCalculator.CalculateScoreForPoolUntilSelectedDay(pool.Participants, pool.TimestampId, short.Parse(args[1]));
    var orderedPresentionResults = OrderAndMapResulsForPresentation(results);
    ConsoleTable.From(orderedPresentionResults).Write();
}
else
{
    foreach (var message in validationResult.Messages)
    {
        Console.WriteLine(message);
    }
}

await host.RunAsync();

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                    retryAttempt)));
}

static IOrderedEnumerable<PresentationResult> OrderAndMapResulsForPresentation(List<Participant> results)
{
    var presentationResut = new List<PresentationResult>();
    foreach (var result in results)
    {
        presentationResut.Add(new PresentationResult
        {
            Name = result.Name,
            Score = result.Score
        });
    }
    return presentationResut.OrderByDescending(x => x.Score).ThenBy(x => x.Name);
}