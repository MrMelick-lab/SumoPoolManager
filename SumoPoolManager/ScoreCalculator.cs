using Microsoft.Extensions.Logging;

namespace SumoPoolManager
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly IWebScrapper _webScrapper;
        private readonly ILogger<ScoreCalculator> _logger;

        public ScoreCalculator(IWebScrapper webScrapper, ILogger<ScoreCalculator> logger)
        {
            _webScrapper = webScrapper;
            _logger = logger;
        }

        public async Task<List<Participant>> CalculateScoreForPoolUntilSelectedDay(List<Participant> participantsWithoutScore, string bashoId, short day)
        {
            var scoreParticipant = new List<Participant>();
            if (participantsWithoutScore?.Any() != true || string.IsNullOrWhiteSpace(bashoId) || day < 1 || day > 15)
                return scoreParticipant;

            var results =  await _webScrapper.GetBashoResults(bashoId, day);

            if (!results.Any())
                return scoreParticipant;

            scoreParticipant = participantsWithoutScore;

            for (short i = 1; i <= day; i++)
            {
                _logger.LogInformation("Day: {i}", i);
                foreach (var participant in scoreParticipant)
                {
                    participant.Score += GetScoreForTheDayForParticipant(results, i, participant);
                    _logger.LogInformation("Participant {participant.Name}'s score is {participant.Score} so far on day {i}", participant.Name, participant.Score, i);
                }
                _logger.LogInformation("End of day: {i}", i);
            }

            return scoreParticipant;
        }

        private static short GetScoreForTheDayForParticipant(List<WinnerOnDay> results, short i, Participant participant)
        {
            short scoreForTheDay = 0;
            foreach (var rikishi in participant.Rikishis)
            {
                if (rikishi.DayOfEntry > i)
                    continue;

                if (results.Any(r => string.Equals(r.Name.Trim(), rikishi.Name.Trim(), StringComparison.InvariantCultureIgnoreCase) && r.Day == i))
                    scoreForTheDay++;
            }

            return scoreForTheDay;
        }
    }
}
