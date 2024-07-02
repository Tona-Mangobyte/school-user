using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IRoleServices
    {
        Task<IEnumerable<Role>> GetAllRolesService();
        Task<Role?> GetRoleService(Guid id);
        Task<List<Role>?> CheckExistingRolesService(List<string> roles);
        Task<Role?> CreateRoleService(RoleDto roleDto);
        Task<string> UpdateRoleService(Guid id, RoleDto roleDto);
        Task<string> DeleteRoleService(Guid id);
    }
}