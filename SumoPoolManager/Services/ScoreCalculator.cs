using Microsoft.Extensions.Logging;
using SumoPoolManager.Models;

namespace SumoPoolManager.Services
{
    /// <summary>
    /// Service class used to calcute the score using a list of particiants and the results obtained from the injected WebScrapper
    /// </summary>
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly IWebScrapper _webScrapper;
        private readonly ILogger<ScoreCalculator> _logger;

        public ScoreCalculator(IWebScrapper webScrapper, ILogger<ScoreCalculator> logger)
        {
            _webScrapper = webScrapper;
            _logger = logger;
        }

        /// <summary>
        /// This function takes a list of Participants, a bashoId (which identifies a sumo wrestling tournament), and a day (between 1 and 15), and calculates the scores of the participants up to and including the selected day.
        /// </summary>
        /// <param name="participantsWithoutScore">The pool particiants who have not their scores calculated yet</param>
        /// <param name="bashoId">The identifier of a sumo wrestling tournament with format YYYYMM. So the basho of new year basho of 2023 wich happens in januray have the id 202301</param>
        /// <param name="day">Between 1 and 15, the last of score calculation</param>
        /// <returns>The participants with their scores calculated</returns>
        public async Task<List<Participant>> CalculateScoreForPoolUntilSelectedDay(List<Participant> participantsWithoutScore, string bashoId, short day, List<InjuredRikishi> injuredRikishis)
        {
            var scoreParticipant = new List<Participant>();
            if (participantsWithoutScore?.Any() != true || string.IsNullOrWhiteSpace(bashoId) || day < 1 || day > 15)
                return scoreParticipant;

            var results = await _webScrapper.GetBashoResults(bashoId, day);

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
