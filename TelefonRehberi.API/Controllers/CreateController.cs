using Microsoft.AspNetCore.Mvc;
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
            var create = new Application.Create();
            var eklenenKisiId = create.KisiEkle(kisi);
            return Ok(eklenenKisiId);
        }
    }
}
