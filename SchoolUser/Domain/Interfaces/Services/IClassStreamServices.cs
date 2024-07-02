using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IClassStreamServices
    {
        Task<IEnumerable<ClassStream>> GetAllService();
        Task<ClassStream?> GetByIdService(Guid id);
        Task<ClassStream?> CreateService(ClassStreamDto ClassStreamDto);
        Task<string> UpdateService(Guid id, ClassStreamDto ClassStreamDto);
        Task<string> DeleteService(Guid id);
    }
}