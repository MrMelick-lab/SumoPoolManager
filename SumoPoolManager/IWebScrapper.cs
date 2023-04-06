namespace SumoPoolManager
{
    public interface IWebScrapper
    {
        Task<string> GetBashoResults();
    }
}