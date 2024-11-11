using Microsoft.AspNetCore.Mvc;
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

		[HttpGet]
		public async Task<IActionResult> GetPosts()
		{
			var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/posts");
			return Content(response, "application/json");
		}

		[HttpGet]
		public async Task<IActionResult> GetUsers()
		{
			var response = await _httpClient.GetStringAsync("https://jsonplaceholder.typicode.com/users");
			return Content(response, "application/json");
		}

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
