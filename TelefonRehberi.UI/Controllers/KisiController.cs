using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TelefonRehberi.Shared;

namespace TelefonRehberi.UI.Controllers
{
    public class KisiController : Controller
    {
        private readonly APIService _apiService;
        public KisiController(APIService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(long Id)
        {
            var kisi = await _apiService.GetKisiByIdAsync(Id);
            return View(kisi);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Kisi kisi)
        {
            long Id = await _apiService.KisiEkleAsync(kisi);
            return RedirectToAction("Index", new { Id });
        }

        [HttpGet]
        public async Task<IActionResult> Guncelle(long Id)
        {
            var kisi = await _apiService.GetKisiByIdAsync(Id);
            return View(kisi);
        }
    }
}
