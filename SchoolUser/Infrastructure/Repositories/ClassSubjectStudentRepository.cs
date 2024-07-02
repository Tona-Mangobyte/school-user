using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassSubjectStudentRepository : IClassSubjectStudentRepository
    {
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;
        private const string EntityName = "Student";

        public ClassSubjectStudentRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassSubjectStudent>> GetAllAsync()
        {
            return await _dbContext.ClassSubjectStudentTable!.ToListAsync();
        }

        public async Task<IEnumerable<ClassSubjectStudent>> GetListByStudentIdAsync(Guid studentId)
        {
            return await _dbContext.ClassSubjectStudentTable!.Where(css => css.StudentId == studentId).ToListAsync();
        }

        public async Task<ClassSubjectStudent?> GetByIdAsync(Guid id)
        {
            return await _dbContext.ClassSubjectStudentTable!.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ClassSubjectStudent?> GetByClassSubjectIdAndStudentIdAsync(Guid classSubjectId, Guid studentId)
        {
            return await _dbContext.ClassSubjectStudentTable!.FirstOrDefaultAsync(x => x.ClassSubjectId == classSubjectId && x.StudentId == studentId);
        }

        public async Task<ClassSubjectStudent> CreateAsync(ClassSubjectStudent classSubjectStudent)
        {
            await _dbContext.ClassSubjectStudentTable!.AddAsync(classSubjectStudent);
            await _dbContext.SaveChangesAsync();
            return classSubjectStudent;
        }

        public async Task<bool> UpdateAsync(ClassSubjectStudent classSubjectStudent)
        {
            var existing = await _dbContext.ClassSubjectStudentTable!.FindAsync(classSubjectStudent.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            existing.ClassSubjectId = classSubjectStudent.ClassSubjectId;
            existing.StudentId = classSubjectStudent.StudentId;

            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.ClassSubjectStudentTable!.FindAsync(id);

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

            return true;
        }

    }
}