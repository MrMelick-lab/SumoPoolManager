using HtmlAgilityPack;
using System.Text;

namespace SumoPoolManager
{
    public class WebScrapper : IWebScrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WebScrapper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, int>> GetBashoResults(string bashoId, int day)
        {
            var results = new Dictionary<string, int>();
            var client = _httpClientFactory.CreateClient();
            for (int i = 1; i <= day; i++)
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
                var resultsNode = doc.DocumentNode.SelectNodes("//table[@class='tk_table']").FirstOrDefault();

                if (resultsNode == null)
                    return results;

                //Loop through each bout and print the winner and loser
                foreach (var boutNode in resultsNode.SelectNodes(".//tr"))
                {
                    var node = boutNode.SelectSingleNode(".//td[@class='tk_kekka']");
                    if (node == null)
                        continue;

                    var tkEastRikishiNameAndScore = GetNameAndScoreFromBoutNode(boutNode, "east");
                    var tkWestRikishiNameAndScore = GetNameAndScoreFromBoutNode(boutNode, "west");

                    if (results.ContainsKey(tkEastRikishiNameAndScore.name))
                        results[tkEastRikishiNameAndScore.name] = tkEastRikishiNameAndScore.score;
                    else
                        results.Add(tkEastRikishiNameAndScore.name, tkEastRikishiNameAndScore.score);

                    if (results.ContainsKey(tkWestRikishiNameAndScore.name))
                        results[tkWestRikishiNameAndScore.name] = tkWestRikishiNameAndScore.score;
                    else
                        results.Add(tkWestRikishiNameAndScore.name, tkWestRikishiNameAndScore.score);
                }
            }
            return results;
        }

        private (string name, int score) GetNameAndScoreFromBoutNode(HtmlNode boutNode, string direction)
        {
            return (boutNode.SelectSingleNode($".//td[@class='tk_{direction}']//center//a[1]").InnerText,
                int.Parse(boutNode.SelectSingleNode($".//td[@class='tk_{direction}']//center//a[2]//font").InnerText.Split(" ")[0].Split("-")[0]));
        }
    }
}
