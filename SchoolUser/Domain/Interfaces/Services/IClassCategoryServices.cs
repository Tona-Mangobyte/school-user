using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IClassCategoryServices
    {
        Task<IEnumerable<ClassCategory>> GetAllService();
        Task<ClassCategory?> GetByIdService(Guid id);
        Task<bool> CheckIdValidityService(Guid id);
        Task<ClassCategory?> CreateService(ClassCategoryDto ClassCategoryDto);
        Task<string> UpdateService(Guid id, ClassCategoryDto ClassCategoryDto);
        Task<string> DeleteService(Guid id);
    }
}