using Microsoft.AspNetCore.Mvc;

namespace TelefonRehberi.UI.Controllers
{
    public class JQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string HtmlTableGetir()
        {
            var h = System.IO.File.ReadAllText("wwwroot/html/table.html");
            return h;
        }
    }
}
