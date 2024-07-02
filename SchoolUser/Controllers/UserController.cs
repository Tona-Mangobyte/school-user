using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/users")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly ITokenServices _tokenServices;
        private readonly IUserRoleServices _userRoleServices;
        private readonly IStudentServices _studentServices;

        public UserController(IUserServices userServices, ITokenServices tokenServices, IUserRoleServices userRoleServices, IStudentServices studentServices)
        {
            _userServices = userServices;
            _tokenServices = tokenServices;
            _userRoleServices = userRoleServices;
            _studentServices = studentServices;
        }

        [HttpGet("all")]
        // [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userServices.GetAllUsersService();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paginated")]
        // [Authorize(Roles = "admin,teacher")]
        public async Task<IActionResult> GetPaginatedUsers([FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string? roleTitle)
        {
            try
            {
                return Ok(await _userServices.GetPaginatedUsersService(pageNumber, pageSize, roleTitle));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                return Ok(await _userServices.GetUserByIdService(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, GetUserRequestDto getUserDto)
        {
            try
            {
                return Ok(await _userServices.UpdateUserService(id, getUserDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("bulk-update-students")]
        public async Task<IActionResult> UpdateStudentsInBulk([FromBody] UpdateStudentsDto updateStudentsDto)
        {
            try
            {
                return Ok(await _studentServices.UpdateStudentInBulkService(updateStudentsDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                return Ok(await _userServices.DeleteUserService(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("verify-account")]
        public async Task<IActionResult> VerifyAccount(VerifyAccountDto verifyAccountDto)
        {
            try
            {
                return Ok(await _userServices.VerifyAccountService(verifyAccountDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            try
            {
                return Ok(await _userServices.ChangePasswordService(changePasswordDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("refresh-token")]
        public async Task<IActionResult> RefreshJwtToken(Guid id, RefreshJwtTokenDto refreshJwtTokenDto)
        {
            try
            {
                return Ok(await _tokenServices.RefreshJwtTokenService(id, refreshJwtTokenDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            try
            {
                return Ok(await _userServices.ResetPasswordService(resetPasswordDto));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}