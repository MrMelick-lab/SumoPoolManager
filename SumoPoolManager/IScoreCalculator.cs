namespace SumoPoolManager
{
    public interface IScoreCalculator
    {
        Task<List<Participant>> CalculateScoreForPoolUntilSelectedDay(List<Participant> participantsSansScore, string bashoId, short day);
    }
}