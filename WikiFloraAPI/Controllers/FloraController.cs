using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        [Authorize]
        [HttpGet("Get/pageNumber={pageNumber:int}&pageSize={pageSize:int}&orderByGenus={orderByGenus:bool}")]
        public async Task<ActionResult<Page<Flora>>> GetAll(int pageSize, int pageNumber,bool orderByGenus)
        {
            ClaimsIdentity? currentUser = HttpContext.User.Identity as ClaimsIdentity;
            if(currentUser != null)
            {
                IEnumerable<Claim>claims = currentUser.Claims;
              /*  foreach (var item in claims)
                {
                    Console.WriteLine(item.Type + " " + item.Value);
                }*/
            }
            int _floraListSize = await _floraService.FloraCount();
            int maxPageNumber = (_floraListSize % pageSize == 0)
                               ? _floraListSize / pageSize
                               : (_floraListSize / pageSize) + 1;
            List<Flora?> floras = await _floraService.GetFloraList(pageNumber, pageSize);
            if (orderByGenus) floras = await _floraService.GetFloraListByGenus(pageNumber, pageSize);

            Page<Flora> _page = new Page<Flora>{ Data = floras!,
                                        currentPageIndex = pageNumber,
                                        MaxPageIndex = maxPageNumber - 1 };

            return Ok(_page);
        }

        [HttpGet("floraCount")]
        public async Task<ActionResult<int>> FloraCount()
        {
            return Ok(await _floraService.FloraCount());
        }
        [HttpGet("Get/{banglaName}")]
        public async Task<ActionResult<Flora>> GetFloraByName(string banglaName)
        {
            return await _floraService.GetFloraByName(banglaName);
        }
        [HttpPost]
        public async Task<ActionResult<Flora>> Post(Flora flora)
        {
            return Ok(await _floraService.AddFlora(flora));
        }
    }
}
