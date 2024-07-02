using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories;

public interface IUserRoleRepository
{
    Task<IEnumerable<UserRole>> GetByUserIdAsync(Guid UserId);
    Task<UserRole> CreateAsync (UserRole userRole);
    Task<bool> DeleteByUserIdAsync(Guid userId);
}
