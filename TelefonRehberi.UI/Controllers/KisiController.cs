using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace TelefonRehberi.UI.Controllers
{
    public class KisiController : Controller
    {
        private readonly Read _read;
        private readonly Create _create;
        private readonly Update _update;
        private readonly Delete _delete;

        public KisiController(Read read, Create create, Update update, Delete delete)
        {
            _read = read;
            _create = create;
            _update = update;
            _delete = delete;
        }

        public IActionResult Index(long Id)
        {
            var kisi = _read.GetById(Id);
            return View(kisi);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Kisi kisi)
        {
            if (!ModelState.IsValid)
            {
                return View(kisi); // Hataları göster
            }

            long Id = _create.KisiEkle(kisi);
            return RedirectToAction("Index", new { Id });
        }

        [HttpGet]
        public IActionResult Guncelle(long Id)
        {
            var kisi = _read.GetById(Id);
            return View(kisi);
        }

        [HttpPost]
        public IActionResult Guncelle(Kisi kisi)
        {
            long Id = _update.KisiGuncelle(kisi);
            return RedirectToAction("Index", new { Id });
        }

        public IActionResult Sil(long Id)
        {
            bool sonuc = _delete.KisiSilById(Id);
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
