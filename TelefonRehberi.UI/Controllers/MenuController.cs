using Microsoft.AspNetCore.Mvc;

namespace TelefonRehberi.UI.Controllers
{
    public class MenuController : Controller
    {
        private readonly APIService _apiService;
        public MenuController(APIService apiService)
        {
            _apiService = apiService;
        }
        public async Task< IActionResult> Index()
        {
            var menuler = await _apiService.GetAllMenuAsync();
            return View(menuler);
        }
    }
}
