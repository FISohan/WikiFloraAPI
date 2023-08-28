using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WikiFloraAPI.Models;
using WikiFloraAPI.Services;

namespace WikiFloraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("all")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _userService.getAllUser());
        }
        [HttpPost]
        public async Task<ActionResult<User>>AddUser(User user)
        {
            return  Ok( await _userService.addUser(user));
        }
    }
}
