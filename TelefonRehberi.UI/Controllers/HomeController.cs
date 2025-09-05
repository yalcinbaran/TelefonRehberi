using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TelefonRehberi.UI.Models;

namespace TelefonRehberi.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Read _read;

        public HomeController(ILogger<HomeController> logger, Read read)
        {
            _logger = logger;
            _read = read;
        }

        public IActionResult Index()
        {
            List<Kisi> kisiler = _read.GetAll();
            return View(kisiler);
        }

        [HttpPost]
        public IActionResult Index(string? keyword = null)
        {
            var filteredKisiler = _read.GetAllBySearchKeyword(keyword);
            ViewBag.AramaKelimesi = keyword;
            return View(filteredKisiler);
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
