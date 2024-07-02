using Microsoft.EntityFrameworkCore;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Infrastructure.Repositories;

public class UserRoleRepository : IUserRoleRepository
{
    private readonly DBContext _dbContext;
    public UserRoleRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Domain.Models.UserRole>> GetByUserIdAsync(Guid UserId)
    {
        return await _dbContext.UserRoleTable!.Where(ur => ur.UserId == UserId).ToListAsync();
    }

    public async Task<Domain.Models.UserRole> CreateAsync(Domain.Models.UserRole userRole)
    {
        await _dbContext.UserRoleTable!.AddAsync(userRole);
        await _dbContext.SaveChangesAsync();
        return userRole;
    }

    public async Task<bool> DeleteByUserIdAsync(Guid userId)
    {
        var existing = await _dbContext.UserRoleTable!.FindAsync(userId);

        if (existing == null)
        {
            return false;
        }

        _dbContext.UserRoleTable!.Remove(existing);
        int result = await _dbContext.SaveChangesAsync();

        return result > 0;
    }
}
