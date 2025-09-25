using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TelefonRehberi.Operations;
using TelefonRehberi.Operations.Models;
using TelefonRehberi.UI.Models;

namespace TelefonRehberi.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeOperations _homeOperations;

        public HomeController(ILogger<HomeController> logger, HomeOperations homeOperations)
        {
            _logger = logger;
            _homeOperations = homeOperations;
        }

        public IActionResult Index()
        {
            IEnumerable<Kisi> kisiler = _homeOperations.GetAll();
            return View(kisiler);
        }

        [HttpPost]
        public IActionResult Index(string? keyword = null)
        {
            var filteredKisiler = _homeOperations.GetAllBySearchKeyword(keyword);
            ViewBag.AramaKelimesi = keyword;
            return new JsonResult(filteredKisiler);
        }

        [HttpGet]
        public IActionResult GetAllWithDataTable(string? keyword = null)
        {
            var filteredKisiler = _homeOperations.GetAllDataTableBySearchKeyword(keyword);
            return new JsonResult(filteredKisiler);
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
