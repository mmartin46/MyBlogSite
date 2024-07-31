using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class AppRepository : IAppRepository
    {

        public readonly AppDatabaseContext _context = null;
        private readonly IMapper _mapper;

        public AppRepository(AppDatabaseContext appDatabaseContext, IMapper mapper)
        {
            _context = appDatabaseContext;
            _mapper = mapper;
        }


        public async Task<List<AppModel>> GetApps()
        {
            var apps = new List<AppModel>();
            var allApps = await _context.AllApps.ToListAsync();
            if (allApps.Any() == true)
            {
                foreach (var app in allApps)
                {
                    var model = _mapper.Map<AppModel>(app);
                    apps.Add(model);
                }
            }

            return apps;
        }

        public async Task<int> AddApp(AppModel app)
        {
            var appModel = _mapper.Map<Apps>(app);

            await _context.AllApps.AddAsync(appModel);
            await _context.SaveChangesAsync();
            return appModel.Id;
        }

        public async Task<List<AppModel>> GetApp(string? name, string? language, string? author)
        {
            List<AppModel> apps = await GetApps();

            var appQuery = (from app in apps
                            where ((name == null || app.Name.Contains(name)) &&
                              (language == null || app.Language.Contains(language)) &&
                              (author == null || app.Authors.Contains(author)))
                            select app).ToList();

            return appQuery;
        }

        public async Task<List<AppModel>> GetAppById(int id)
        {
            List<AppModel> apps = await GetApps();
            apps = apps.Where(app => app.Id == id).ToList();
            return apps;
        }
    }
}
