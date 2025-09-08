using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Operations;
using TelefonRehberi.Operations.Models;

namespace TelefonRehberi.UI.Controllers
{
    public class KisiController : Controller
    {
        private readonly KisiOperations _kisiOperations;

        public KisiController(KisiOperations kisiOperations)
        {
            _kisiOperations = kisiOperations;
        }

        public IActionResult Index(long Id)
        {
            var kisi = _kisiOperations.GetById(Id);
            return View(kisi);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View(new Kisi());
        }

        [HttpPost]
        public IActionResult Ekle(Kisi kisi)
        {
            if (!ModelState.IsValid)
            {
                return View(kisi); // Hataları göster
            }

            long Id = _kisiOperations.KisiEkle(kisi);
            return RedirectToAction("Index", new { Id });
        }

        [HttpGet]
        public IActionResult Guncelle(long Id)
        {
            var kisi = _kisiOperations.GetById(Id);
            return View(kisi);
        }

        [HttpPost]
        public IActionResult Guncelle(Kisi kisi)
        {
            long Id = _kisiOperations.KisiGuncelle(kisi);
            return RedirectToAction("Index", new { Id });
        }

        public IActionResult Sil(long Id)
        {
            bool sonuc = _kisiOperations.KisiSilById(Id);
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
