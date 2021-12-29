using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
//using System.Text.Json;

namespace testingdocker.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : Controller
    {
        public NewsController()
        {

        }

        [HttpGet]
        public JsonResult Get()
        {
            var result = TestNews(); //JsonSerializer.Serialize(TestNews());
            return Json(result);
        }

        private IEnumerable<NewsItem> TestNews()
        {
            var news = new List<NewsItem>();
            for(int i=1; i<=10; i++)
            {
                var item = new NewsItem();
                item.Id = i;
                item.Name = $"News #{i}";
                item.Resource.Add($"Something {i}");
                item.Resource.Add($"Anything {i}");
                item.Resource.Add($"Something else, but still {i}");
                news.Add(item);
            }
            return news;
        }

    }
}
