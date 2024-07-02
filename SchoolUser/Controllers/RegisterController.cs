using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/register")]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "admin")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterServices _userServices;
        private readonly IHeaderServices _headerServices;

        public RegisterController(IRegisterServices userServices, IHeaderServices headerServices)
        {
            _userServices = userServices;
            _headerServices = headerServices;
        }

        [HttpPost]
        public async Task<IActionResult> Register(AddUserRequestDto user)
        {
            try
            {
                string? tokenHeader = _headerServices.GetAuthorizationHeader(HttpContext)!;

                return Ok(await _userServices.CreateUserService(user, tokenHeader));
            }
            catch (Exception ex)
            {
                throw new BusinessRuleException($"Register Error {ex.Message}");
            }

        }
    }
}