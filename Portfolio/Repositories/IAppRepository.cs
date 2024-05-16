using Portfolio.Models;

namespace Portfolio.Repositories
{
    public interface IAppRepository
    {
        Task<int> AddApp(AppModel app);
        Task<List<AppModel>> GetApp(string? name, string? language, string? author);
        Task<List<AppModel>> GetAppById(int id);
        Task<List<AppModel>> GetApps();
    }
}