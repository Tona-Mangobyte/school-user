using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Domain.Interfaces.Services;
using System.Text.Json;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DBContext _dbContext;
        private readonly ICacheServices<User> _cacheServices;
        private const string cacheKey_GetUserById = "GetUserById";
        private readonly IReturnValueConstants _returnValueConstants;
        private const string EntityName = "Teacher";
        public TeacherRepository(DBContext dbContext, ICacheServices<User> cacheServices, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _cacheServices = cacheServices;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _dbContext.TeacherTable!.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetListBySubjectIdAsync(Guid subjectId)
        {
            var teachers = await _dbContext.TeacherTable!
                .AsNoTracking()
                .Where(t => t.ClassSubjectTeachers!.Any(cst => cst.ClassSubject!.SubjectId == subjectId))
                .Include(t => t.ClassSubjectTeachers)!
                .ThenInclude(cst => cst.ClassSubject)
                .ThenInclude(cs => cs!.Subject)
                .ToListAsync();

            return teachers;
        }

        public async Task<Teacher?> GetByIdAsync(Guid id)
        {
            return await _dbContext.TeacherTable!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Teacher?> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.TeacherTable!.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<Teacher> CreateAsync(Teacher teacher)
        {
            await _dbContext.TeacherTable!.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
            return teacher;
        }

        public async Task<bool> UpdateAsync(Teacher teacher)
        {
            var existing = await _dbContext.TeacherTable!.FirstOrDefaultAsync(t => t.Id == teacher.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            existing.ServiceStatus = teacher.ServiceStatus;
            existing.IsAvailable = teacher.IsAvailable;
            existing.UserId = teacher.UserId;
            existing.ClassCategoryId = teacher.ClassCategoryId;
            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{existing!.UserId}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.TeacherTable!.FindAsync(id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            _dbContext.Remove(existing);
            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{existing!.Id}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return true;
        }

    }
}