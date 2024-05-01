using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Repositories;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly AppRepository _appRepository = null;

        [ViewData]
        public List<AppModel> apps { get; set; }

        public ProjectsController(AppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        [Route("Projects/{category:alpha?}")]
        public async Task<ViewResult> Index(string ?category)
        {
            var apps = await _appRepository.GetApps();

            switch (category)
            {
                case "Games":
                    apps = apps.Where(x => x.Category.Contains("Games")).ToList();
                    break;
                case "Mobile":
                    apps = apps.Where(x => x.Category.Contains("Mobile")).ToList();
                    break;
                case "Data":
                    apps = apps.Where(x => x.Category.Contains("Data")).ToList();
                    break;
            }

            ViewData["category"] = category;

            return View(apps);
        }

        [Route("/GetApp/{id:int}")]
        public async Task<ViewResult> GetApp(int id)
        {
            var allApps = await _appRepository.GetApps();
            var app = await _appRepository.GetAppById(id);

            ViewData["apps"] = allApps;

            AppModel firstAppById = app.FirstOrDefault();
            if (firstAppById == null)
            {
                return View(null);
            }
            
            return View(firstAppById);
        }
    }
}
