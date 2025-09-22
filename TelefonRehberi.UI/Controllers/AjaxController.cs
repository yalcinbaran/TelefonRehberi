using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Operations;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.UI.Controllers
{
    public class AjaxController : Controller
    {
        private readonly HomeOperations _homeOperations;

        public AjaxController(HomeOperations homeOperations)
        {
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
            return View(filteredKisiler);
        }

        [HttpPost("AramaAjax")]
        public IActionResult AramaAjax([FromBody] AramaRequest request)
        {
            var filteredKisiler = _homeOperations.GetAllBySearchKeyword(request.Keyword);
            ViewBag.AramaKelimesi = request.Keyword;
            return new JsonResult(filteredKisiler);
        }

        public class AramaRequest
        {
            public string? Keyword { get; set; }
        }
    }
}
