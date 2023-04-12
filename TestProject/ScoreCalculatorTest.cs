using NSubstitute;

namespace TestProject
{
    public class ScoreCalculatorTest
    {
        private readonly ScoreCalculator _scoreCalculator;
        private readonly IWebScrapper _webScrapper;
        private readonly Fixture _fixture;

        public ScoreCalculatorTest() 
        {
            _webScrapper = Substitute.For<IWebScrapper>();
            _scoreCalculator = new ScoreCalculator(_webScrapper);
            _fixture = new Fixture();
        }

        public static IEnumerable<object[]> GetInvalidParameters()
        {
            yield return new object[] { new List<Participant>(), "test", 1 };
            yield return new object[] { new List<Participant> { new Participant() }, " ", 1 };
            yield return new object[] { new List<Participant> { new Participant() }, "test", 0 };
            yield return new object[] { new List<Participant> { new Participant() }, "test", 16 };
        }


        [Theory]
        [MemberData(nameof(GetInvalidParameters))]
        public async Task GivenInvalidParameterReturnNull(List<Participant> participantsSansScore, string bashoId, short day)
        {
            var results = await _scoreCalculator.CalculateScoreForPoolUntilSelectedDay(participantsSansScore, bashoId, day);

            results.Should().BeEmpty();
           await _webScrapper.DidNotReceive().GetBashoResults(Arg.Any<string>(), Arg.Any<short>());
        }

        [Fact]
        public async Task GivenNullWebScrapperResult_ShouldReturnEmptyResults()
        {
            _webScrapper.GetBashoResults("test", 1).Returns(new List<WinnerOnDay>());

            var results = await _scoreCalculator.CalculateScoreForPoolUntilSelectedDay(new List<Participant> { new Participant() }, "test", 1);

            results.Should().BeEmpty();
        }
    }
}
