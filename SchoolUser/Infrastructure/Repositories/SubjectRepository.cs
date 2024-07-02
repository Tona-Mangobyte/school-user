using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SchoolUser.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DBContext _dbContext;

        public SubjectRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<Subject> GetSubjectsQuery()
        {
            return _dbContext.SubjectTable!
                .AsNoTracking()
                .Select(s => new Subject
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    ClassCategories = s.ClassSubjects!.Select(cs => new ClassCategory
                    {
                        Id = cs.ClassCategory!.Id,
                        Code = cs.ClassCategory!.Code,
                        BatchId = cs.ClassCategory!.BatchId,
                        ClassStreamId = cs.ClassCategory!.ClassStreamId,
                    }).ToList(),
                });
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await GetSubjectsQuery()
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task<Subject?> GetByIdAsync(Guid id)
        {
            return await GetSubjectsQuery()
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Subject?> GetByNameAsync(string name)
        {
            return await GetSubjectsQuery()
                .Where(s => s.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<Subject> CreateAsync(Subject subject)
        {
            await _dbContext.SubjectTable!.AddAsync(subject);
            await _dbContext.SaveChangesAsync();
            return subject;
        }

        public async Task<bool> UpdateAsync(Subject subject)
        {
            var existing = await _dbContext.SubjectTable!.FindAsync(subject.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Name = subject.Name;
            existing.Code = subject.Code;
            
            int result = await _dbContext.SaveChangesAsync();
            Console.WriteLine(result);

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.SubjectTable!.FindAsync(id);

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