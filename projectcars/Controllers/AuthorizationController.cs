using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Users;
using projectcars.DTO;
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
        public async Task<IActionResult> Login([FromBody] LoginUserRequest req)
        {
            try
            {
                var loginDto = await _usersService.Login(req.PhoneNumber, req.Password);

                Response.Cookies.Append("projcars", loginDto.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None
                });

                var response = new
                {
                    loginDto.Name,
                    loginDto.Surname,
                    loginDto.PhoneNumber
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest req)
        {
            await _usersService.Register(req.Name, req.Surname, req.PhoneNumber, req.Password);

            return Ok();
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("projcars");

            return Ok();
        }

        [HttpPost("checktoken")]
        [Authorize]
        public async Task<IActionResult> GetUserDataByToken() 
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
                var userId = userIdClaim?.Value;

                if (userId == null)
                {
                    return Unauthorized("User  ID is missing in the token.");
                }

                var user = await _usersService.GetUserDataById(Guid.Parse(userId));

                var response = new
                {
                    user.Name,
                    user.SurName,
                    user.PhoneNumber
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
