using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IBatchServices
    {
        Task<IEnumerable<Batch>> GetAllService();
        Task<Batch?> GetByIdService(Guid id);
        Task<Batch?> CreateService(BatchDto batchDto);
        Task<string> UpdateService(Guid id, BatchDto batchDto);
        Task<string> DeleteService(Guid id);
    }
}