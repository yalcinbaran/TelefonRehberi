using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.API.Application;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteController : ControllerBase
    {
        [HttpDelete("KisiSil/{id}")]
        public IActionResult KisiSil(long id)
        {
            var delete = new Delete();
            var sonuc = delete.KisiSilById(id);
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
