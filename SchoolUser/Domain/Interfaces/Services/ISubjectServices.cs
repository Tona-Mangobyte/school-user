using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface ISubjectServices
    {
        Task<IEnumerable<Subject>> GetAllService();
        Task<Subject?> GetByIdService(Guid id);
        Task<Subject?> CreateService(SubjectDto SubjectDto);
        Task<string> UpdateService(Guid id, SubjectDto SubjectDto);
        Task<string> DeleteService(Guid id);
    }
}