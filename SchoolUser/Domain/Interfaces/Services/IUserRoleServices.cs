using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IUserRoleServices
    {
        Task CreateUserRoleService(Guid id, List<Role> roles);
    }
}