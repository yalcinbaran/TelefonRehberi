using Microsoft.AspNetCore.Mvc;
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
            if (!ModelState.IsValid)
            {
                return View(kisi); // Hataları göster
            }

            long Id = await _apiService.KisiEkleAsync(kisi);
            return RedirectToAction("Index", new { Id });
        }

        [HttpGet]
        public async Task<IActionResult> Guncelle(long Id)
        {
            var kisi = await _apiService.GetKisiByIdAsync(Id);
            return View(kisi);
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(Kisi kisi)
        {
            long Id = await _apiService.KisiGuncelleAsync(kisi);
            return RedirectToAction("Index", new { Id });
        }

        public async Task<IActionResult> Sil(long Id)
        {
            bool sonuc = await _apiService.SilAsync(Id);
            if (sonuc)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", new { Id });
            }
        }

    }
}
