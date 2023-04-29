using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace SumoPoolManager
{
    /// <summary>
    /// Service class wich goes to web scrappe the results of a particular basho up to a day
    /// </summary>
    public class WebScrapper : IWebScrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<WebScrapper> _logger;

        public WebScrapper(IHttpClientFactory httpClientFactory, ILogger<WebScrapper> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Get the results of a Sumo Basho tournament up to and including a given day, by scraping a website.
        /// Then, it initializes a list of WinnerOnDay objects called results and a HttpClient object called client.
        /// It then loops through each day up to and including the selected day, and for each day, it scrapes the results page for that day, extracts the winner(s) of each bout, and adds them to the results list as a WinnerOnDay object
        /// </summary>
        /// <param name="bashoId">The identifier of a sumo wrestling tournament with format YYYYMM. So the basho of new year basho of 2023 wich happens in januray have the id 202301</param>
        /// <param name="day">Between 1 and 15 the limit yp to wich webscrappe the winners/param>
        /// <returns>A list of the winner of each day up to the day parameter</returns>
        public async Task<List<WinnerOnDay>> GetBashoResults(string bashoId, short day)
        {
            if(string.IsNullOrWhiteSpace(bashoId) || day < 1 || day > 15)
                return new List<WinnerOnDay>();

            var results = new List<WinnerOnDay>();
            var client = _httpClientFactory.CreateClient("SumoBasho");
            for (short i = 1; i <= day; i++)
            {
                // URL of the sumo basho results page to scrape
                string? url = $"https://sumodb.sumogames.de/Results.aspx?b={bashoId}&d={i}";

                // Create a WebClient object and download the HTML from the URL
                string? html = await client.GetStringAsync(url);
                if (string.IsNullOrWhiteSpace(html))
                    return results;

                // Load the HTML into an HtmlDocument object
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                // Find the HTML element that contains the basho results
                var resultsNode = doc.DocumentNode.SelectNodes("//table[@class='tk_table']").First();

                //Loop through each bout and get the winner
                foreach (var boutNode in resultsNode.SelectNodes(".//tr"))
                {
                    var node = boutNode.SelectSingleNode(".//td[@class='tk_kekka']");
                    if (node == null)
                        continue;

                    var winner = ExtractWinner(boutNode, node);
                    results.Add(new WinnerOnDay { Day = i, Name = winner });
                }
                var winnersOfTheDay = string.Join(", ", results.Where(w => w.Day == i).Select(w => w.Name).ToList());
                _logger.LogInformation("Winners of day {i}: {winnersOfTheDay}", i, winnersOfTheDay);
            }
            return results;
        }

        /// <summary>
        /// <para>
        /// Extract the name of the winner of a bout from the HTML of the results page for a given day.
        /// hecks if there is an HTML image element with the src attribute equal to 'img/hoshi_shiro.gif' in the node object. If there is, it means the winner is the East wrestler, so it checks if there is also an HTML image element with the src attribute equal to 'img/hoshi_fusensho.gif'. If there is, it means the winner won by default, so the function returns the name of the West wrestler. 
        /// If there isn't, the function returns the name of the East wrestler.
        /// </para>
        /// <para>
        /// If there is no image element with the src attribute equal to 'img/hoshi_shiro.gif' in the node object, it means the winner is the West wrestler, so it checks if there is an image element with the src attribute equal to 'img/hoshi_fusensho.gif'.
        /// If there is, it means the winner won by default, so the function returns the name of the East wrestler. 
        /// If there isn't, the function returns the name of the West wrestler.
        /// </para>
        /// </summary>
        /// <param name="boutNode">HtmlNode object representing the HTML element that contains the information about the bout</param>
        /// <param name="node">HtmlNode object representing the HTML element that contains the winner of the bout.</param>
        /// <returns>The name of the winner of the bout as a string</returns>
        private static string ExtractWinner(HtmlNode boutNode, HtmlNode node)
        {
            var imgShiro = node.SelectSingleNode(".//img[@src='img/hoshi_shiro.gif']");
            var imgFusensho = node.SelectSingleNode(".//img[@src='img/hoshi_fusensho.gif']");
            string winner;
            if (imgShiro == null)
            {
                if (imgFusensho == null)
                    winner = boutNode.SelectSingleNode(".//td[@class='tk_west']//center//a[1]").InnerText;
                else
                    winner = boutNode.SelectSingleNode(".//td[@class='tk_east']//center//a[1]").InnerText;
            }
            else
            {
                if (imgFusensho == null)
                    winner = boutNode.SelectSingleNode(".//td[@class='tk_east']//center//a[1]").InnerText;
                else
                    winner = boutNode.SelectSingleNode(".//td[@class='tk_west']//center//a[1]").InnerText;
            }

            return winner;
        }
    }
}
