using HtmlAgilityPack;

namespace SumoPoolManager
{
    public class WebScrapper : IWebScrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WebScrapper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

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
                var resultsNode = doc.DocumentNode.SelectNodes("//table[@class='tk_table']").FirstOrDefault();

                //Loop through each bout and get the winner
                foreach (var boutNode in resultsNode.SelectNodes(".//tr"))
                {
                    var node = boutNode.SelectSingleNode(".//td[@class='tk_kekka']");
                    if (node == null)
                        continue;

                    var winner = ExtractWinner(boutNode, node);

                    results.Add(new WinnerOnDay { Day = i, Name = winner });
                }
            }
            return results;
        }

        private static string ExtractWinner(HtmlNode boutNode, HtmlNode node)
        {
            var imgShiro = node.SelectSingleNode(@".//img[@src='img/hoshi_shiro.gif']");
            var imgFusensho = node.SelectSingleNode(@".//img[@src='img/hoshi_fusensho.gif']");
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
