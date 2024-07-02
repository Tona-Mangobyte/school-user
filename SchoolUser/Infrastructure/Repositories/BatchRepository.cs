using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolUser.Infrastructure.Repositories
{
    public class BatchRepository : IBatchRepository
    {
        private readonly DBContext _dbContext;

        public BatchRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<Batch> GetBatchesQuery()
        {
            return _dbContext.BatchTable!
                .AsNoTracking()
                .Select(b => new Batch
                {
                    Id = b.Id,
                    Name = b.Name,
                    ClassCategories = b.ClassCategories!,
                    ClassStreams = b.ClassCategories!
                        .Select(cc => new ClassStream
                        {
                            Id = cc.ClassStream!.Id,
                            Name = cc.ClassStream!.Name,
                            Code = cc.ClassStream!.Code,
                        })
                        .GroupBy(cs => new { cs.Id, cs.Name, cs.Code })
                        .Select(g => g.First())
                        .ToList()
                });
        }

        public async Task<IEnumerable<Batch?>> GetAllAsync()
        {
            return await GetBatchesQuery()
                .OrderBy(b => b.Name)
                .ToListAsync();
        }

        public async Task<Batch?> GetByIdAsync(Guid id)
        {
            return await GetBatchesQuery()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Batch?> GetByNameAsync(string name)
        {
            return await GetBatchesQuery()
                .FirstOrDefaultAsync(b => b.Name == name);
        }

        public async Task<Batch> CreateAsync(Batch batch)
        {
            await _dbContext.BatchTable!.AddAsync(batch);
            await _dbContext.SaveChangesAsync();
            return batch;
        }

        public async Task<bool> UpdateAsync(Batch batch)
        {
            var existing = await _dbContext.BatchTable!.FindAsync(batch.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Name = batch.Name;
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.BatchTable!.FindAsync(id);

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