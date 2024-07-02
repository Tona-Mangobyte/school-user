using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassSubjectRepository : IClassSubjectRepository
    {
        private readonly DBContext _dbContext;

        public ClassSubjectRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<ClassSubject> GetClassSubjectsQuery()
        {
            return _dbContext.ClassSubjectTable!
                .AsNoTracking()
                .Select(cs => new ClassSubject
                {
                    Id = cs.Id,
                    Code = cs.Code,
                    ClassCategoryId = cs.ClassCategoryId,
                    SubjectId = cs.SubjectId,
                    Teachers = cs.ClassSubjectTeachers!.Select(cst => cst.Teacher!).ToList(),
                    Students = cs.ClassSubjectStudents!.Select(cst => cst.Student!).ToList(),
                });
        }

        public async Task<IEnumerable<ClassSubject>> GetAllAsync()
        {
            return await GetClassSubjectsQuery()
                .OrderBy(cs => cs.Code)
                .ToListAsync();
        }

        public async Task<ClassSubject?> GetByIdAsync(Guid id)
        {
            return await GetClassSubjectsQuery()
                .Where(cs => cs.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ClassSubject?> GetByCodeAsync(string code)
        {
            return await GetClassSubjectsQuery()
                .Where(cs => cs.Code == code)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ClassSubject>> GetByClassCategoryIdAsync(Guid classCategoryId)
        {
            return await GetClassSubjectsQuery()
                .Where(cs => cs.ClassCategoryId == classCategoryId)
                .ToListAsync();
        }

        public async Task<ClassSubject> CreateAsync(ClassSubject classSubject)
        {
            await _dbContext.ClassSubjectTable!.AddAsync(classSubject);
            await _dbContext.SaveChangesAsync();
            return classSubject;
        }

        public async Task<bool> UpdateAsync(ClassSubject classSubject)
        {
            var existing = await _dbContext.ClassSubjectTable!.FindAsync(classSubject.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Code = classSubject.Code;
            int result = await _dbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.ClassSubjectTable!.FindAsync(id);

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