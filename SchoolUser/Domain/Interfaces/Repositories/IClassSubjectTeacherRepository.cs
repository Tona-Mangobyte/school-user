using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassSubjectTeacherRepository
    {
        Task<IEnumerable<ClassSubjectTeacher>> GetAllAsync();
        Task<IEnumerable<ClassSubjectTeacher>> GetListByTeacherIdAsync(Guid teacherId);
        Task<ClassSubjectTeacher?> GetByIdAsync(Guid id);
        Task<ClassSubjectTeacher?> GetByClassSubjectIdAndTeacherIdAsync(Guid classSubjectId, Guid teacherId);
        Task<ClassSubjectTeacher> CreateAsync(ClassSubjectTeacher classSubjectTeacher);
        Task<bool> UpdateAsync(ClassSubjectTeacher classSubjectTeacher);
        Task<bool> DeleteAsync(Guid id);
    }
}