using System.Text.Json;

namespace SumoPoolManager
{
    public class ScoreCalculator : IScoreCalculator
    {
        private readonly IWebScrapper _webScrapper;

        public ScoreCalculator(IWebScrapper webScrapper)
        {
            _webScrapper = webScrapper;
        }

        public async Task<List<Participant>> CalculateScoreForPoolUntilSelectedDay(List<Participant> participantsSansScore, string bashoId, short day)
        {
            var scoreParticipant = new List<Participant>();
            if (participantsSansScore == null || !participantsSansScore.Any() || string.IsNullOrWhiteSpace(bashoId) || day < 1 || day > 15)
                return scoreParticipant;

            var results =  await _webScrapper.GetBashoResults(bashoId, day);

            if (!results.Any())
                return scoreParticipant;

            scoreParticipant = participantsSansScore;

            for (short i = 1; i <= day; i++)
            {
                foreach (var participant in scoreParticipant)
                {
                    participant.Score += GetScoreForTheDayForParticipant(results, i, participant);
                }
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

                if (results.Any(r => r.Name == rikishi.Name && r.Day == i))
                    scoreForTheDay++;
            }

            return scoreForTheDay;
        }
    }
}
