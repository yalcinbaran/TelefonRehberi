using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Shared;

namespace TelefonRehberi.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly APIService _apiService;
        public MenuController(APIService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var menuler = await _apiService.GetAllMenuAsync();
            return View(menuler);
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        {
            var altMenu = await _apiService.GetAllMenuAsync();
            ViewBag.Menuler = altMenu.OrderBy(x=>x.MenuAdi).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(MenuClass menu)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", await _apiService.GetAllMenuAsync()); // Hataları göster
            }
            bool sonuc = await _apiService.MenuEkleAsync(menu);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Menü eklenirken bir hata oluştu.");
                return View("Index", await _apiService.GetAllMenuAsync());
            }
        }
    }
}
