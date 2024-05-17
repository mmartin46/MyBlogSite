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
        private readonly IAppRepository _appRepository = null;
        private readonly IConfiguration _configuration;

        [ViewData]
        public string Title { get; set; }

        [ViewData]
        public NewsModel[] ApiNews { get; set; }

        [ViewData]
        public List<AppModel> Apps { get; set; }
        public HomeController(IAppRepository appRepository, IConfiguration configuration)
        {
            _appRepository = appRepository;
            _configuration = configuration;
        }

        public async Task<ViewResult> Index()
        {
            ViewData["ApiNews"] = await GetNewsAsync();


            Title = "Home";
            return View();
        }

        public ViewResult AboutMe()
        {
            return View();
        }

        private async Task<NewsModel[]> GetNewsAsync()
        {
            HttpClient client = new HttpClient();


            HttpResponseMessage response = await client.GetAsync(_configuration["news:tech"]);
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
