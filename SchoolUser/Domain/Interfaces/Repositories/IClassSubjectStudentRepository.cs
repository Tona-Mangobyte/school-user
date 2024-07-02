using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassSubjectStudentRepository
    {
        Task<IEnumerable<ClassSubjectStudent>> GetAllAsync();
        Task<IEnumerable<ClassSubjectStudent>> GetListByStudentIdAsync(Guid studentId);
        Task<ClassSubjectStudent?> GetByIdAsync(Guid id);
        Task<ClassSubjectStudent?> GetByClassSubjectIdAndStudentIdAsync(Guid classSubjectId, Guid teacherId);
        Task<ClassSubjectStudent> CreateAsync(ClassSubjectStudent classSubjectStudent);
        Task<bool> UpdateAsync(ClassSubjectStudent classSubjectStudent);
        Task<bool> DeleteAsync(Guid id);
    }
}