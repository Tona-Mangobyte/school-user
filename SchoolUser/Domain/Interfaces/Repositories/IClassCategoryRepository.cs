using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassCategoryRepository
    {
        Task<IEnumerable<ClassCategory>> GetAllAsync();
        Task<ClassCategory?> GetByIdAsync(Guid id);
        Task<ClassCategory?> GetByCodeAsync(string code);
        Task<IEnumerable<Guid>> GetUniqueClassCategoryIdsAsync();
        Task<ClassCategory> CreateAsync(ClassCategory classCategory);
        Task<bool> UpdateAsync(ClassCategory classCategory);
        Task<bool> DeleteAsync(Guid id);
    }
}