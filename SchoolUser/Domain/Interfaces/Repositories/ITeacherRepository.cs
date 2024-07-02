using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<IEnumerable<Teacher>> GetListBySubjectIdAsync(Guid subjectId);
        Task<Teacher?> GetByIdAsync(Guid id);
        Task<Teacher?> GetByUserIdAsync(Guid userId);
        Task<Teacher> CreateAsync(Teacher teacher);
        Task<bool> UpdateAsync(Teacher teacher);
        Task<bool> DeleteAsync(Guid id);
    }
}