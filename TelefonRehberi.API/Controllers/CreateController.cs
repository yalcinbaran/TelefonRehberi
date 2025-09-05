using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.API.Application;
using TelefonRehberi.Shared;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateController : ControllerBase
    {
        [HttpPost("KisiEkle")]
        public IActionResult KisiEkle([FromBody] Kisi kisi)
        {
            var create = new Create();
            var eklenenKisiId = create.KisiEkle(kisi);
            return Ok(eklenenKisiId);
        }

        [HttpPost("MenuEkle")]
        public IActionResult MenuEkle([FromBody] MenuClass menu)
        {
            var create = new Create();
            var eklenenMenuId = create.MenuEkle(menu);
            return Ok(eklenenMenuId);
        }
    }
}
