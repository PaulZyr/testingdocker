using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using testingdocker.webmvc.Models;

namespace testingdocker.webmvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            HttpClient http = new HttpClient();
            var url = "https://localhost:44370/api/News";
            //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("APIKEY", header);
            var data = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;

            var news = JsonConvert.DeserializeObject<List<NewsItem>>(data);

            var result = new News();
            result.NewsList = news;

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult GetJson()
        {
            var one = "Done";
            return Json(one);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
