using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassSubjectRepository
    {
        Task<IEnumerable<ClassSubject>> GetAllAsync();
        Task<ClassSubject?> GetByIdAsync(Guid id);
        Task<ClassSubject?> GetByCodeAsync(string Code);
        Task<IEnumerable<ClassSubject>> GetByClassCategoryIdAsync(Guid classCategoryId);
        Task<ClassSubject> CreateAsync(ClassSubject classSubject);
        Task<bool> UpdateAsync(ClassSubject classSubject);
        Task<bool> DeleteAsync(Guid id);
    }
}