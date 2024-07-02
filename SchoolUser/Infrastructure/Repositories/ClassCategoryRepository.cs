using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassCategoryRepository : IClassCategoryRepository
    {
        private readonly DBContext _dbContext;

        public ClassCategoryRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<ClassCategory> GetClassCategoriesQuery()
        {
            return _dbContext.ClassCategoryTable!
                .AsNoTracking()
                .Select(cc => new ClassCategory
                {
                    Id = cc.Id,
                    Code = cc.Code,
                    BatchId = cc.BatchId,
                    ClassStreamId = cc.ClassStreamId,
                    Subjects = cc.ClassSubjects!.Select(cs => cs.Subject!).ToList(),
                    Students = cc.Students,
                    Teachers = cc.Teachers
                });
        }

        public async Task<IEnumerable<ClassCategory>> GetAllAsync()
        {
            return await GetClassCategoriesQuery()
                .OrderBy(cc => cc.Code)
                .ToListAsync();
        }

        public async Task<ClassCategory?> GetByIdAsync(Guid id)
        {
            return await GetClassCategoriesQuery()
                .Where(cc => cc.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ClassCategory?> GetByCodeAsync(string code)
        {
            return await GetClassCategoriesQuery()
                .Where(cc => cc.Code == code)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Guid>> GetUniqueClassCategoryIdsAsync()
        {
            return await GetClassCategoriesQuery()
                .Select(cc => cc.Id)
                .Distinct()
                .ToListAsync();
        }

        public async Task<ClassCategory> CreateAsync(ClassCategory classCategory)
        {
            await _dbContext.ClassCategoryTable!.AddAsync(classCategory);
            await _dbContext.SaveChangesAsync();
            return classCategory;
        }

        public async Task<bool> UpdateAsync(ClassCategory classCategory)
        {
            var existing = await _dbContext.ClassCategoryTable!.FindAsync(classCategory.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Code = classCategory.Code;
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.ClassCategoryTable!.FindAsync(id);

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