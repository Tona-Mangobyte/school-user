using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolUser.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DBContext _dbContext;
        public RoleRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _dbContext.RoleTable!.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(Guid id)
        {
            return await _dbContext.RoleTable!.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Role?> GetByTitleAsync(string title)
        {
            return await _dbContext.RoleTable!.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            await _dbContext.RoleTable!.AddAsync(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<bool> UpdateAsync(Role role)
        {
            var existing = await _dbContext.RoleTable!.FindAsync(role.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Title = role.Title;
            
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.RoleTable!.FindAsync(id);

            if (existing == null)
            {
                return false;
            }

            _dbContext.Remove(existing);
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }
    }
}