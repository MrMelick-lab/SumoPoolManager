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

        public async Task<string> GetBashoResults()
        {
            // URL of the sumo basho results page to scrape
            var url = "https://sumodb.sumogames.de/Results.aspx?b=202301&d=1";
            var result = string.Empty;
            var stringBuilder = new StringBuilder();

            // Create a WebClient object and download the HTML from the URL
            var client = _httpClientFactory.CreateClient();
            var html = await client.GetStringAsync(url);

            // Load the HTML into an HtmlDocument object
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Find the HTML element that contains the basho results
            var resultsNode = doc.DocumentNode.SelectNodes("//table[@class='tk_table']").FirstOrDefault();

            if (resultsNode == null)
                return result;

            var i = 1;
            //Loop through each bout and print the winner and loser
            foreach (var boutNode in resultsNode.SelectNodes(".//tr"))
            {
                var node = boutNode.SelectSingleNode(".//td[@class='tk_kekka']");
                var winner = string.Empty;
                if (node == null)
                    continue;

                var img = node.SelectSingleNode(@".//img[@src='img/hoshi_kuro.gif']");
                winner = img == null ? boutNode.SelectSingleNode(".//td[@class='tk_east']//center//a[1]").InnerText : boutNode.SelectSingleNode(".//td[@class='tk_west']//center//a[1]").InnerText;
                stringBuilder.AppendLine($"Match: {i} Winner: {winner}");
                i++;
            }
            return stringBuilder.ToString();
        }
    }
}
