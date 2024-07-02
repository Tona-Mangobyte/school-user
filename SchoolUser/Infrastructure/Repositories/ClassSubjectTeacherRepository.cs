using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Domain.Models;
using SchoolUser.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Infrastructure.Repositories
{
    public class ClassSubjectTeacherRepository : IClassSubjectTeacherRepository
    {
        private readonly DBContext _dbContext;
        private readonly IReturnValueConstants _returnValueConstants;
        private const string EntityName = "Teacher";

        public ClassSubjectTeacherRepository(DBContext dbContext, IReturnValueConstants returnValueConstants)
        {
            _dbContext = dbContext;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassSubjectTeacher>> GetAllAsync()
        {
            return await _dbContext.ClassSubjectTeacherTable!.ToListAsync();
        }

        public async Task<IEnumerable<ClassSubjectTeacher>> GetListByTeacherIdAsync(Guid teacherId)
        {
            return await _dbContext.ClassSubjectTeacherTable!.Where(cst => cst.TeacherId == teacherId).ToListAsync();
        }

        public async Task<ClassSubjectTeacher?> GetByIdAsync(Guid id)
        {
            return await _dbContext.ClassSubjectTeacherTable!.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ClassSubjectTeacher?> GetByClassSubjectIdAndTeacherIdAsync(Guid classSubjectId, Guid teacherId)
        {
            return await _dbContext.ClassSubjectTeacherTable!.FirstOrDefaultAsync(x => x.ClassSubjectId == classSubjectId && x.TeacherId == teacherId);
        }

        public async Task<ClassSubjectTeacher> CreateAsync(ClassSubjectTeacher classSubjectTeacher)
        {
            await _dbContext.ClassSubjectTeacherTable!.AddAsync(classSubjectTeacher);
            await _dbContext.SaveChangesAsync();
            return classSubjectTeacher;
        }

        public async Task<bool> UpdateAsync(ClassSubjectTeacher classSubjectTeacher)
        {
            var existing = await _dbContext.ClassSubjectTeacherTable!.FindAsync(classSubjectTeacher.Id);

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }
            existing.ClassSubjectId = classSubjectTeacher.ClassSubjectId;
            existing.TeacherId = classSubjectTeacher.TeacherId;

            int result = await _dbContext.SaveChangesAsync();

            if (result < 1)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _dbContext.ClassSubjectTeacherTable!.FindAsync(id);

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