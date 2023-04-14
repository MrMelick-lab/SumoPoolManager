namespace TestProject
{
    public class ScoreCalculatorTest
    {
        private readonly ScoreCalculator _scoreCalculator;
        private readonly IWebScrapper _webScrapper;
        private readonly Fixture _fixture;
        private readonly List<Participant> _participants = new();
        private readonly List<WinnerOnDay> _results202303day1 = new();

        public ScoreCalculatorTest() 
        {
            _webScrapper = Substitute.For<IWebScrapper>();
            _scoreCalculator = new ScoreCalculator(_webScrapper);
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
            using var expectedResultStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "results202303day1.json"));
            _results202303day1 = JsonSerializer.Deserialize<List<WinnerOnDay>>(expectedResultStream);
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
            results.ElementAt(0).Name.Should().Be("MrMelick");
            results.ElementAt(0).Score.Should().Be(4);
        }
    }
}
