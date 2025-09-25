using Microsoft.AspNetCore.Mvc;
using System.Data;
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
            var dt = _homeOperations.GetAllDataTableBySearchKeyword(keyword);

            var list = new List<Dictionary<string, object>>();

            foreach (DataRow row in dt.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }

            return Ok(list);
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
