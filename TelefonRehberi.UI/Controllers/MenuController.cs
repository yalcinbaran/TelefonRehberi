using Microsoft.AspNetCore.Mvc;
using System.Text;
using TelefonRehberi.Operations;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuOperations _menuOperations;

        public MenuController(MenuOperations menuOperations)
        {
            _menuOperations = menuOperations;
        }

        public IActionResult Index()
        {
            StringBuilder menuString = new();
            var menuler = _menuOperations.GetAllMenu();
            menuString.Append("<ul>");
            string sub = _menuOperations.GetMenuHTML(menuler, 0);
            menuString.Append(sub).Append("<ul>");
            
            ViewBag.MenulerHTML = menuString.ToString();
            return View(menuler);
        }


        [HttpGet]
        public IActionResult Ekle()
        {
            var menuler = _menuOperations.GetAllMenu();
            Dictionary<string, string> menuList = new();
            menuList = _menuOperations.GetMenuList(menuList, menuler, 0);
            ViewData["Menulist"] = menuList;
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(MenuClass menu)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", _menuOperations.GetAllMenu()); // Hataları göster
            }
            bool sonuc = _menuOperations.MenuEkle(menu);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Menü eklenirken bir hata oluştu.");
                return View("Index", _menuOperations.GetAllMenu());
            }
        }
    }
}
