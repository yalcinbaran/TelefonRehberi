using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            string MenulerHTML = "<ul>";
            string sub = GetMenuHTML(menuler, 0);
            MenulerHTML = MenulerHTML + sub + "</ul>";
            ViewBag.MenulerHTML = MenulerHTML;
            return View(menuler);
        }

        private string GetMenuHTML(IEnumerable<MenuClass> menuler, long parentID, string prefix = "")
        {
            string HTMLstr = "";
            var altMenuler = menuler.Where(x => x.ParentId == parentID).OrderBy(x => x.MenuAdi).ToList();
            if (altMenuler.Any())
            {
                for (int i = 0; i < altMenuler.Count; i++)
                {
                    var menu = altMenuler[i];
                    var currentPrefix = string.IsNullOrEmpty(prefix) ? (i + 1).ToString() : prefix + "." + (i + 1);
                    HTMLstr += $"<li>{currentPrefix}{menu.MenuAdi}";
                    HTMLstr += GetMenuHTML(menuler, menu.Id, currentPrefix);
                    HTMLstr += "</li>";
                }
            }
            return HTMLstr;
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            var menuler = _read.GetAllMenu();
            ViewBag.Menuler = menuler.OrderBy(x => x.MenuAdi).ToList();
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
