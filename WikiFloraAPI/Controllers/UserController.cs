using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
        [HttpGet("{userId}")]
        public async Task<ActionResult<User?>>GetUser(string userId)
        {
            User? user = await _userService.getUser(userId);
            if (user == null) return NotFound(null);
            return Ok(user);
        }
        [Authorize]
        [HttpGet("existed")]
        public async Task<ActionResult<bool>> UserExisted()
        {
            // string userId = User.Claims.Single(c => c.Type.Equals("sub")).Value;
            //Console.WriteLine(">>>" +  userId);
            var claims = HttpContext.User.Claims;
            foreach (var item in claims)
            {
                Console.WriteLine(">>>>>>>>" + item.Type + " " + item.Value);
            }
          //  bool existed = await _userService.isUserExist(userId);
            return Ok(true);
        }
        [HttpPost]
        public async Task<ActionResult<User>>AddUser(User user)
        {
            return  Ok( await _userService.addUser(user));
        }
    }
}
