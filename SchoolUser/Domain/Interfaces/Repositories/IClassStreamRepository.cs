using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IClassStreamRepository
    {
        Task<IEnumerable<ClassStream>> GetAllAsync();
        Task<ClassStream?> GetByIdAsync(Guid id);
        Task<ClassStream?> GetByNameAsync(string Name);
        Task<ClassStream> CreateAsync(ClassStream ClassStream);
        Task<bool> UpdateAsync(ClassStream ClassStream);
        Task<bool> DeleteAsync(Guid id);
    }
}