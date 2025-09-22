using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Operations;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.UI.Controllers
{
    public class HomeJQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            ConnectionProvider connectionProvider = new();
            HomeOperations homeOperations = new(connectionProvider);
            IEnumerable<Kisi> kisiler = homeOperations.GetAll();
            return new JsonResult(kisiler);
        }

        [HttpPost]
        public IActionResult Index(string? keyword = null)
        {
            ConnectionProvider connectionProvider = new();
            HomeOperations homeOperations = new(connectionProvider);
            var filteredKisiler = homeOperations.GetAllBySearchKeyword(keyword);
            ViewBag.AramaKelimesi = keyword;
            return new JsonResult(filteredKisiler);
        }
    }
}
