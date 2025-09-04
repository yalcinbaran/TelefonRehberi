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

        [HttpPost]
        public async Task<IActionResult> Index(string? keyword = null)
        {
            var tumKisiler = await _apiService.GetTumKisilerAsync();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return View(tumKisiler);
            }
            ViewBag.AramaKelimesi = keyword;
            keyword = keyword.ToLower();
            var filteredKisiler = tumKisiler.Where(k =>
                (!string.IsNullOrEmpty(k.Adi) && k.Adi.ToLower().Replace(" ", "").Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.Soyadi) && k.Soyadi.ToLower().Replace(" ", "").Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.CepTel) && k.CepTel.ToLower().Replace(" ", "").Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.IsTel) && k.IsTel.ToLower().Replace(" ", "").Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.Adres1) && k.Adres1.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(k.Adres2) && k.Adres2.ToLower().Contains(keyword))
            ).ToList();
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
