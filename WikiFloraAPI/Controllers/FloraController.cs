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
        [HttpGet("Get/pageNumber={pageNumber:int}&pageSize={pageSize:int}")]
        public async Task<ActionResult<Page<Flora>>> GetAll(int pageSize, int pageNumber)
        {
            int _floraListSize = await _floraService.FloraCount();
            int maxPageNumber = (_floraListSize % pageSize == 0)
                               ? _floraListSize / pageSize
                               : (_floraListSize / pageSize) + 1;
            List<Flora?> floras = await _floraService.GetFloraList(pageNumber, pageSize);

            Page<Flora> _page = new Page<Flora>{ Data = floras,
                                        currentPageIndex = pageNumber,
                                        MaxPageIndex = maxPageNumber - 1 };

            return Ok(_page);
        }

        [HttpGet("floraCount")]
        public async Task<ActionResult<int>> FloraCount()
        {
            return Ok(await _floraService.FloraCount());
        }
        [HttpPost]
        public async Task<ActionResult<Flora>> Post(Flora flora)
        {
            return Ok(await _floraService.AddFlora(flora));
        }
    }
}
