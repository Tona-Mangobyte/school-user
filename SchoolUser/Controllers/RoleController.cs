using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolUser.Controllers
{
    [ApiController]
    [Route("api/roles")]
    [Authorize(Roles = "admin")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;

        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllRole()
        {
            return Ok(await _roleServices.GetAllRolesService());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRole(Guid id)
        {
            return Ok(await _roleServices.GetRoleService(id));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole(RoleDto roleDto)
        {
            return Ok(await _roleServices.CreateRoleService(roleDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole (Guid id, RoleDto roleDto)
        {
            return Ok(await _roleServices.UpdateRoleService(id, roleDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            return Ok(await _roleServices.DeleteRoleService(id));
        }
    }
}