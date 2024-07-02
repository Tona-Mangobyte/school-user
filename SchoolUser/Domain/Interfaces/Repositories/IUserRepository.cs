using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User?>> GetAllAsync();
        Task<(IEnumerable<User?>, int)> GetPaginatedUsersAsync(int pageNumber, int pageSize, string? roleTitle);
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByJwtTokenAsync(string jwtToken);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task AutoUpdateUserAgeAsync();
        Task<bool> DeleteAsync(Guid id);
        Task DeleteInactiveUsersAsync();
        Task DeleteUnregisteredUsersAsync();
        Task<bool> VerifyUserAsync(User user);
        Task<bool> ChangePasswordAsync(User user);
        Task<User?> UpdateTokenAsync(User user);
    }
}