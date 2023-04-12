namespace SumoPoolManager
{
    public interface IWebScrapper
    {
        Task<List<WinnerOnDay>> GetBashoResults(string bashoId, short day);
    }
}