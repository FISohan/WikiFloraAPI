using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("Get/pageNumber={pageNumber:int}&pageSize={pageSize:int}&orderByGenus={orderByGenus:bool}")]
        public async Task<ActionResult<Page<Flora>>> GetAll(int pageSize, int pageNumber,bool orderByGenus)
        {
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
        public async Task<ActionResult<Flora?>> GetFloraByName(string banglaName)
        {
            Flora? flora = await _floraService.GetFloraByName(banglaName);
            if(flora == null) return NotFound();
            return Ok(flora);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Flora>> Post(Flora flora)
        {
            ClaimData claimData = ClaimService.getClaimData(User.Claims);
            flora.Contributer = claimData.sub;
            flora.ContributerName = claimData.name;
            return Ok(await _floraService.AddFlora(flora));
        }

        [Authorize("Admin")]
        [HttpPut("aprrove")]
        public async Task<ActionResult<bool>>ApproveFlora(Guid floraID)
        {
            Console.WriteLine(">>hhh>>>" + floraID);
            bool success = await _floraService.approveFlora(floraID);
            if(!success) return BadRequest("May Flora ID is not valid");
            return Ok(success);
        }
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<ActionResult<bool>> UpdateFlora(Flora updatedFlora,Guid id)
        {
            Flora? flora = await _floraService.GetFloraById(id);
            if (flora == null) return false;

            flora.OthersName = updatedFlora.OthersName;
            flora.ScientificName = updatedFlora.ScientificName;
            flora.BanglaName = updatedFlora.BanglaName;
            flora.Description = updatedFlora.Description;
            flora.Photos = updatedFlora.Photos;
            flora.Hierarchy = updatedFlora.Hierarchy;
            flora.Reference = updatedFlora.Reference;
            
            bool sucess = await _floraService.UpadateFlora(flora);
            if (!sucess) return BadRequest();
            return sucess;
        }
        [HttpGet("disapproved")]
        public async Task<ActionResult<List<Flora>>> GetDisapproveFlora()
        {
            List<Flora> flora = await _floraService.GetDisapprovePost();
            return flora;
        }
        [HttpGet("{floraId}")]
        public async Task<ActionResult<Flora>> GetById(Guid floraId)
        {
            Flora? flora = await _floraService.GetFloraById(floraId);
            if(flora == null) return NotFound();
            return flora;
        }
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            bool success = await _floraService.deleteFlora(id);
            if (!success) return NotFound("Delete process is not success");
            return success;
        }

        [HttpGet("get/byUser")]
        public async Task<ActionResult<List<Flora>>> GetFloraByUserId(string userId)
        {
            List<Flora> floras = await _floraService.GetFloraByUser(userId);
            return Ok(floras);
        }
        [Authorize]
        [HttpGet("get/byUser/auth")]
        public async Task<ActionResult<List<Flora>>> GetFloraByUserIdAuth()
        {
            string userId = ClaimService.getClaimData(User.Claims).sub;
            List<Flora> floras = await _floraService.GetFloraByUserAuth(userId);
            return Ok(floras);
        }

    }
}
