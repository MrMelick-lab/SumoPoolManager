namespace TestProject
{
    public class WebScrapperTest
    {
        private readonly string htmlPageOf202301;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly WebScrapper webScrapper;
        private HttpClient? httpClient;

        public WebScrapperTest()
        {
            htmlPageOf202301 = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "202301.html"));
            httpClientFactory = Substitute.For<IHttpClientFactory>();
            webScrapper = new WebScrapper(httpClientFactory);
        }

        [Theory]
        [InlineData("", 1)]
        [InlineData("  ", 1)]
        [InlineData("2023", 0)]
        [InlineData("2023", 16)]
        public async Task GivenInvalidArguments_ShouldReturnEmptyList(string bashoId, short day)
        {
            var results = await webScrapper.GetBashoResults(bashoId, day);

            results.Should().BeEmpty();
            httpClientFactory.DidNotReceiveWithAnyArgs().CreateClient();
        }

        [Fact]
        public async Task GivenValidArgumentsButEmptyResponse_ShouldReturnEmptyResults()
        {
            //Arrange
            var msgHandler = new MockHttpMessageHandler();
            var bashoId = "202301";
            short day = 1;
            msgHandler.When($"https://sumodb.sumogames.de/Results.aspx?b={bashoId}&d={day}").Respond("text/plain", string.Empty);
            httpClient = new(msgHandler);
            httpClientFactory.CreateClient("SumoBasho").Returns(httpClient);

            //Act
            var results = await webScrapper.GetBashoResults(bashoId, day);

            //Assert
            results.Should().BeEmpty();
        }

        [Fact]
        public async Task GivenValidArgumentsAndResponse_ShouldReturnValidResults()
        {
            //Arrange
            var msgHandler = new MockHttpMessageHandler();
            var bashoId = "202301";
            short day = 1;
            msgHandler.When($"https://sumodb.sumogames.de/Results.aspx?b={bashoId}&d={day}").Respond("text/plain", htmlPageOf202301);
            httpClient = new(msgHandler);
            httpClientFactory.CreateClient("SumoBasho").Returns(httpClient);
            using var expectedResultStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "results202301day1.json"));
            var expectedResults = await JsonSerializer.DeserializeAsync<List<BoutResult>>(expectedResultStream);

            //Act
            var results = await webScrapper.GetBashoResults(bashoId, day);

            //Assert
            results.Should().BeEquivalentTo(expectedResults);
        }
    }
}