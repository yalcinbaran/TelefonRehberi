using Microsoft.AspNetCore.Mvc;
using TelefonRehberi.API.Application;

namespace TelefonRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            Read read = new();
            var kisiler = read.GetAll();
            return Ok(kisiler);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(long id)
        {
            var kisi = new Read().GetById(id);
            return Ok(kisi);
        }
    }
}
