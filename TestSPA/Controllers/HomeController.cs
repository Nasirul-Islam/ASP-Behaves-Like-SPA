using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using TestSPA.Models;

namespace TestSPA.Controllers
{
	public class HomeController : Controller
	{
		private readonly HttpClient _httpClient;
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
		{
			_logger = logger;
			_httpClient=httpClient;
		}

		public IActionResult Index()
		{
			return View();
		}

		/**/
		[HttpGet]
		public async Task<IActionResult> GetPosts()
		{
			var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
            // ViewModel Approch using Model & Razor Syntex
            var posts = JsonConvert.DeserializeObject<List<Post>>(response);
            //return View("Index", posts); // Passing posts data to the main Index view

			// Return posts data to partial view
            return PartialView("_PostsPartial", posts); 

            // Simple Approch to fetch data ---------
            //return Content(response, "application/json");
        }

		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users");
            // ViewModel Approch using Model & Razor Syntex 
            var users = JsonConvert.DeserializeObject<List<User>>(response);
            //return View("Index", users); // Passing users data to the main Index view

			// Return users data to partial view
            return PartialView("_UsersPartial", users); 

            // Simple Approch to fetch data ---------
            //return Content(response, "application/json");
        }
        /**/

        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
