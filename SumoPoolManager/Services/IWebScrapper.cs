using SumoPoolManager.Models;

namespace SumoPoolManager.Services
{
    public interface IWebScrapper
    {
        Task<List<WinnerOnDay>> GetBashoResults(string bashoId, short day);
    }
}