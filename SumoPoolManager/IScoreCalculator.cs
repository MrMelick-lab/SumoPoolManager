namespace SumoPoolManager
{
    public interface IScoreCalculator
    {
        public Task<Pool> CalculateScoreForPoolUntilSelectedDay(Pool pool, short day);
    }
}