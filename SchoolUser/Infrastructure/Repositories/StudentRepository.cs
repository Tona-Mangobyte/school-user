using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DBContext _dbContext;
        private readonly ICacheServices<User> _cacheServices;
        private const string cacheKey_GetUserById = "GetUserById";
        private readonly IReturnValueConstants _returnValueConstants;
        private const string EntityName = "Student";

        public StudentRepository(DBContext dbContext, ICacheServices<User> cacheServices, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _cacheServices = cacheServices;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbContext.StudentTable!.AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _dbContext.StudentTable!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Student?> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.StudentTable!.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<Student> CreateAsync(Student student)
        {
            await _dbContext.StudentTable!.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var existing = await _dbContext.StudentTable!.FirstOrDefaultAsync(s => s.Id == student.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            existing.EntranceYear = student.EntranceYear;
            existing.EstimatedExitYear = student.EstimatedExitYear;
            existing.RealExitYear = student.RealExitYear;
            existing.ExitReason = student.ExitReason;
            existing.ClassCategoryId = student.ClassCategoryId;

            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            var cacheKey = $"{cacheKey_GetUserById}_{existing!.UserId}";
            _cacheServices.RemoveCacheObject(cacheKey);

            return true;
        }

        public async Task<bool> UpdateBulkAsync(UpdateStudentsDto updateDto)
        {
            var studentsToUpdate = await _dbContext.StudentTable!
                .Where(student => updateDto.StudentIds.Contains(student.Id))
                .ToListAsync();

            if (!studentsToUpdate.Any())
            {
                return false;
            }

            var uniqueClassCategoryIds = studentsToUpdate.Select(student => student.ClassCategoryId).Distinct().Count();

            if (uniqueClassCategoryIds == 1)
            {
                if (studentsToUpdate.All(s => s.EntranceYear == updateDto.EntranceYear &&
                s.EstimatedExitYear == updateDto.EstimatedExitYear &&
                s.RealExitYear == updateDto.RealExitYear &&
                s.ExitReason == updateDto.ExitReason &&
                s.ClassCategoryId == updateDto.ClassCategoryId))
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, "students"));
                }
            }
            else
            {
                if (studentsToUpdate.All(s => s.EntranceYear == updateDto.EntranceYear &&
                s.EstimatedExitYear == updateDto.EstimatedExitYear &&
                s.RealExitYear == updateDto.RealExitYear &&
                s.ExitReason == updateDto.ExitReason))
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, "students"));
                }
            }

            foreach (var student in studentsToUpdate)
            {
                student.EntranceYear = updateDto.EntranceYear;
                student.EstimatedExitYear = updateDto.EstimatedExitYear;
                student.RealExitYear = updateDto.RealExitYear;
                student.ExitReason = updateDto.ExitReason;

                if (updateDto.ClassCategoryId != null && uniqueClassCategoryIds == 1)
                {
                    student.ClassCategoryId = updateDto.ClassCategoryId;
                }
            }

            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.StudentTable!.FindAsync(id);

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