using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Repositories
{
    public interface IBatchRepository
    {
        Task<IEnumerable<Batch?>> GetAllAsync();
        Task<Batch?> GetByIdAsync(Guid id);
        Task<Batch?> GetByNameAsync(string Name);
        Task<Batch> CreateAsync(Batch batch);
        Task<bool> UpdateAsync(Batch batch);
        Task<bool> DeleteAsync(Guid id);
    }
}