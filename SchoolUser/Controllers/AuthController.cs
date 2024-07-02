using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;
        private readonly IHeaderServices _headerServices;

        public AuthController(IAuthServices loginUserServices, IHeaderServices headerServices)
        {
            _authServices = loginUserServices;
            _headerServices = headerServices;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            return Ok(await _authServices.LoginService(loginRequestDto));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(Guid id)
        {
            var result = await _authServices.LogoutService(id);
            return Ok(result);
        }
    }
}