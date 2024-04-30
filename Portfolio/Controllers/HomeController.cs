using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Diagnostics;
using Portfolio.Repositories;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Portfolio.Responses;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppRepository _appRepository = null;

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public NewsModel[] ApiNews { get; set; }

        [ViewData]
        public List<AppModel> Apps { get; set; }
        public HomeController(AppRepository appRepository)
        {
            _appRepository = appRepository;
        }

        public async Task<ViewResult> Index()
        {
            var apps = await _appRepository.GetApps();
            ViewData["ApiNews"] = await GetNewsAsync();


            Title = "Home";
            return View(apps);
        }

        public ViewResult AboutMe()
        {
            return View();
        }

        private async Task<NewsModel[]> GetNewsAsync()
        {
            HttpClient client = new HttpClient();


            HttpResponseMessage response = await client.GetAsync("https://newsdata.io/api/1/news?apikey=pub_42749fa5aab948b19253c5c9d10df047a737a&q=news&country=us&language=en&category=technology");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                // Deserialize JSON response
                var newsData = JsonConvert.DeserializeObject<NewsApiResponse>(data);
                // Populate NewsModel objects
                var results = newsData.Results;
                return results;
            }
            else
            {
                return null;
            }
        }

        public ViewResult ContactMe()
        {
            return View();
        }

    }
}
