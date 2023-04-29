using Microsoft.Extensions.Logging;
using SumoPoolManager.Models;
using SumoPoolManager.Services;

namespace TestProject
{
    public class ScoreCalculatorTest
    {
        private readonly ScoreCalculator _scoreCalculator;
        private readonly IWebScrapper _webScrapper;
        private readonly Fixture _fixture;
        private readonly List<Participant> _participants = new();
        private readonly List<WinnerOnDay> _results202303day1 = new();
        private readonly List<WinnerOnDay> _results202303day15 = new();
        private readonly ILogger<ScoreCalculator> _logger;

        public ScoreCalculatorTest()
        {
            _webScrapper = Substitute.For<IWebScrapper>();
            _logger = Substitute.For<ILogger<ScoreCalculator>>();
            _scoreCalculator = new ScoreCalculator(_webScrapper, _logger);
            _fixture = new Fixture();
            _participants.Add(new Participant
            {
                Name = "MrMelick",
                Rikishis = new List<Rikishi>
                {
                    new Rikishi
                    {
                        Name = "Takakeisho"
                    },
                    new Rikishi
                    {
                        Name = "Hoshoryu"
                    },
                    new Rikishi
                    {
                        Name = "Wakamotoharu"
                    },
                    new Rikishi
                    {
                        Name = "Kotonowaka"
                    },
                    new Rikishi
                    {
                        Name = "Tamawashi"
                    },
                    new Rikishi
                    {
                        Name = "Ryuden"
                    },
                    new Rikishi
                    {
                        Name = "Daieisho"
                    },
                    new Rikishi
                    {
                        Name = "Myogiryu",
                        DayOfEntry = 7
                    }
                }
            });
            using var expectedResult202303day1Stream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "results202303day1.json"));
            _results202303day1 = JsonSerializer.Deserialize<List<WinnerOnDay>>(expectedResult202303day1Stream);
            using var expectedResult202303day15Stream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "results202303day15.json"));
            _results202303day15 = JsonSerializer.Deserialize<List<WinnerOnDay>>(expectedResult202303day15Stream);
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

        [Fact]
        public async Task GivenResultOfDay1_ShouldReturnExpectedResults()
        {
            _webScrapper.GetBashoResults("202303", 1).Returns(_results202303day1);

            var results = await _scoreCalculator.CalculateScoreForPoolUntilSelectedDay(_participants, "202303", 1);

            results.Should().HaveCount(1);
            results[0].Name.Should().Be("MrMelick");
            results[0].Score.Should().Be(4);
        }

        [Fact]
        public async Task GivenResultOfDay15_ShouldReturnExpectedResults()
        {
            _webScrapper.GetBashoResults("202303", 15).Returns(_results202303day15);

            var results = await _scoreCalculator.CalculateScoreForPoolUntilSelectedDay(_participants, "202303", 15);

            results.Should().HaveCount(1);
            results[0].Name.Should().Be("MrMelick");
            results[0].Score.Should().Be(52);
        }
    }
}
