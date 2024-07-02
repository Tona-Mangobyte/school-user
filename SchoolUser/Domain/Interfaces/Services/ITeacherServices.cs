using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface ITeacherServices
    {
        Task<bool> CreateTeacher(TeacherRequestDto teacherRequestDto);
        Task<bool> UpdateTeacher(GetUserRequestDto getUserDto, Teacher? teacher);
    }
}