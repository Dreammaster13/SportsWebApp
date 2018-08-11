using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ButterCMS;



namespace SportsWebApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private static string _apiToken = "1cadd5d5c66eed9dbec3bf8a8a8df3c7b9f05e04";

        private ButterCMSClient _client;

        public BlogController ()
        {
            _client = new ButterCMSClient(_apiToken);
        }

        [Route("Blog/nba-blog-post")]
        public async Task<ActionResult> ShowPost(string slug)
        {
            var response = await _client.RetrievePostAsync(slug);
            ViewBag.Post = response.Data;
            return View("Post");
        }

       
    }
}
