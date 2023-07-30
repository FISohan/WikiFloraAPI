using Microsoft.AspNetCore.Mvc;
using WikiFloraAPI.Models;
using WikiFloraAPI.Services;

namespace WikiFloraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloraController : ControllerBase
    {
        private readonly IFloraService _floraService;

        public FloraController(IFloraService floraService)
        {
            _floraService = floraService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Flora?>>> GetAll()
        {
            List<Flora?> floras = await _floraService.GetFloraList();
            return Ok(floras);
        }
        [HttpPost]
        public async Task<ActionResult<Flora>> Post(Flora flora)
        {
            return Ok(await _floraService.AddFlora(flora));
        }
    }
}
