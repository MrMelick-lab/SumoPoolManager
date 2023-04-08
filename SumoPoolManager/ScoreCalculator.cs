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

        public async Task<Pool> CalculateScoreForPoolUntilSelectedDay(Pool pool, short day)
        {
            var results =  await _webScrapper.GetBashoResults(pool.TimestampId, day);
            for (short i = 1; i <= day; i++)
            {
                foreach (var participant in pool.Participants)
                {
                    short scoreForTheDay = 0;
                    foreach (var rikishi in participant.Rikishis)
                    {
                        if (rikishi.DayOfEntry > i)
                            continue;

                        if (results.Any(r => r.Name == rikishi.Name && r.Day == i && r.Win))
                        {
                            scoreForTheDay++;
                        }
                    }
                    participant.Score += scoreForTheDay;
                }
            }

            return pool;
        }
    }
}
