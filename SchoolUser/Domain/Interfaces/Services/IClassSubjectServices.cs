using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IClassSubjectServices
    {
        Task<IEnumerable<ClassSubject>> GetAllService();
        Task<ClassSubject?> GetByIdService(Guid id);
        Task<ClassSubject?> CreateService(ClassSubjectDto ClassSubjectDto);
        Task<string> UpdateService(Guid id, ClassSubjectDto ClassSubjectDto);
        Task<string> DeleteService(Guid id);
    }
}