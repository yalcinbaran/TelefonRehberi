using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TelefonRehberi.Shared;
using TelefonRehberi.UI.Models;

namespace TelefonRehberi.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly APIService _apiService;

        public HomeController(ILogger<HomeController> logger, APIService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public async Task< IActionResult> Index()
        {
            List<Kisi> kisiler = await _apiService.GetTumKisilerAsync();
            return View(kisiler);
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
