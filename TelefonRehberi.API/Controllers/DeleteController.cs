using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.Shared;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete("KisiSil")]
        public IActionResult KisiSil([FromBody] Kisi kisi)
        {
            var delete = new Application.Delete();
            var sonuc = delete.KisiSil(kisi);
            return Ok(sonuc);
        }

        [HttpDelete("KisiTopluSil")]
        public IActionResult KisiTopluSil([FromBody] List<long> kisiIdler)
        {
            var delete = new Application.Delete();
            var sonuc = delete.KisiTopluSil(kisiIdler);
            return Ok(sonuc);
        }

    }
}
