using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Shared;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        [HttpPut("KisiGuncelle")]
        public IActionResult KisiGuncelle([FromBody] Kisi kisi)
        {
            var update = new Application.Update();
            var guncellenenKisiId = update.KisiGuncelle(kisi);
            return Ok(guncellenenKisiId);
        }
    }
}
