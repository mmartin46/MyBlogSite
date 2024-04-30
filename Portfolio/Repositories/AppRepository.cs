using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Repositories
{
    public class AppRepository
    {

        public readonly AppDatabaseContext _context = null;

        public AppRepository(AppDatabaseContext appDatabaseContext)
        {
            _context = appDatabaseContext;
        }


        public async Task<List<AppModel>> GetApps()
        {
            var apps = new List<AppModel>();
            var allApps = await _context.AllApps.ToListAsync();
            if (allApps.Any() == true)
            {
                foreach (var app in allApps)
                {
                    apps.Add(new AppModel()
                    {
                        Id = app.Id,
                        Authors = app.Authors,
                        Name = app.Name,
                        Description = app.Description,
                        Language = app.Language,
                        Link = app.Link,
                        Picture = app.Picture                     
                    });
                }
            }

            return apps;
        }

        public async Task<int> AddApp(AppModel app)
        {
            var appModel = new Apps()
            {
                Id = app.Id,
                Name = app.Name,
                Description = app.Description,
                Language = app.Language,
                Link = app.Link,
                Picture = app.Picture,
                Authors = app.Authors
            };


           await _context.AllApps.AddAsync(appModel);
           await _context.SaveChangesAsync();
           return appModel.Id;
        }

        public async Task<List<AppModel>> GetApp(string ?name, string ?language, string ?author)
        {
            List<AppModel> apps = await GetApps();

            apps = apps.Where(app =>
                (name == null || app.Name.Contains(name)) &&
                (language == null || app.Language.Contains(language)) &&
                (author == null || app.Authors.Contains(author))
            ).ToList();

            return apps;
        }

        public async Task<List<AppModel>> GetAppById(int id)
        {
            List<AppModel> apps = await GetApps();
            apps = apps.Where(app => app.Id == id).ToList();
            return apps;
        }
    }
}
