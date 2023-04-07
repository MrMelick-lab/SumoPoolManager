namespace SumoPoolManager
{
    public interface IWebScrapper
    {
        Task<List<BoutResult>> GetBashoResults(string bashoId, short day);
    }
}