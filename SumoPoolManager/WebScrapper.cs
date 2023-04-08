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

        public async Task<List<BoutResult>> GetBashoResults(string bashoId, short day)
        {
            if(string.IsNullOrWhiteSpace(bashoId) || day < 1 || day > 15)
                return new List<BoutResult>();

            var results = new List<BoutResult>();
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

                //Loop through each bout and print the winner and loser
                foreach (var boutNode in resultsNode.SelectNodes(".//tr"))
                {
                    var node = boutNode.SelectSingleNode(".//td[@class='tk_kekka']");
                    if (node == null)
                        continue;

                    var imgShiro = node.SelectSingleNode(@".//img[@src='img/hoshi_shiro.gif']");
                    var winner = imgShiro == null ? boutNode.SelectSingleNode(".//td[@class='tk_west']//center//a[1]").InnerText : boutNode.SelectSingleNode(".//td[@class='tk_east']//center//a[1]").InnerText;
                    results.Add(new BoutResult { Day = i, Name = winner, Win = true });
                }
            }
            return results;
        }
    }
}
