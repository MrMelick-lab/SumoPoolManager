namespace SumoPoolManager
{
    public interface IWebScrapper
    {
        Task<Dictionary<string, int>> GetBashoResults(string bashoId, int day);
    }
}