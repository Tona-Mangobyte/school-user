using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassStreamRepository : IClassStreamRepository
    {
        private readonly DBContext _dbContext;

        public ClassStreamRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<ClassStream> GetClassStreamsQuery()
        {
            return _dbContext.ClassStreamTable!
                .AsNoTracking()
                .Select(ss => new ClassStream
                {
                    Id = ss.Id,
                    Name = ss.Name,
                    Code = ss.Code,
                    ClassCategories = ss.ClassCategories,
                    Batches = ss.ClassCategories!.Select(cc => new Batch
                    {
                        Id = cc.Batch!.Id,
                        Name = cc.Batch!.Name
                    })
                    .GroupBy(b => new { b.Id, b.Name })
                    .Select(g => g.First())
                    .ToList()
                });
        }

        public async Task<IEnumerable<ClassStream>> GetAllAsync()
        {
            return await GetClassStreamsQuery()
                .OrderBy(ss => ss.Name)
                .ToListAsync();
        }

        public async Task<ClassStream?> GetByIdAsync(Guid id)
        {
            return await GetClassStreamsQuery()
                .Where(ss => ss.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ClassStream?> GetByNameAsync(string Name)
        {
            return await _dbContext.ClassStreamTable!
                .Include(b => b.ClassCategories)
                .FirstOrDefaultAsync(x => x.Name == Name);
        }

        public async Task<ClassStream> CreateAsync(ClassStream ClassStream)
        {
            await _dbContext.ClassStreamTable!.AddAsync(ClassStream);
            await _dbContext.SaveChangesAsync();
            return ClassStream;
        }

        public async Task<bool> UpdateAsync(ClassStream ClassStream)
        {
            var existing = await _dbContext.ClassStreamTable!.FindAsync(ClassStream.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Name = ClassStream.Name;
            existing.Code = ClassStream.Code;
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.ClassStreamTable!.FindAsync(id);

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