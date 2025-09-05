using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace TelefonRehberi.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly Read _read;
        private readonly Create _create;

        public MenuController(Read read, Create create)
        {
            _read = read;
            _create = create;
        }
        public IActionResult Index()
        {
            var menuler = _read.GetAllMenu();
            return View(menuler);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            var menuler = _read.GetAllMenu();
            ViewBag.Menuler = menuler.OrderBy(x=>x.MenuAdi).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(MenuClass menu)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", _read.GetAllMenu()); // Hataları göster
            }
            bool sonuc = _create.MenuEkle(menu);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Menü eklenirken bir hata oluştu.");
                return View("Index", _read.GetAllMenu());
            }
        }
    }
}
