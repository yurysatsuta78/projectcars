using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Users;
using projectcars.Models;
using projectcars.Services;

namespace projectcars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorizationController : ControllerBase
    {
        private readonly UsersService _usersService;

        public AuthorizationController(UsersService usersService) 
        {
            _usersService = usersService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginUserRequest req)
        {
            try
            {
                var token = await _usersService.Login(req.PhoneNumber, req.Password);

                Response.Cookies.Append("projcars", token);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] RegisterUserRequest req)
        {
            await _usersService.Register(req.Name, req.Surname, req.PhoneNumber, req.Password);

            return Ok();
        }
    }
}
