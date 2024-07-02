using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IStudentServices
    {
        Task<bool> CreateStudent(StudentRequestDto studentRequestDto);
        Task<bool> UpdateStudent(GetUserRequestDto getUserDto, Student? student);
        Task<string> UpdateStudentInBulkService(UpdateStudentsDto updateStudentsDto);
    }
}