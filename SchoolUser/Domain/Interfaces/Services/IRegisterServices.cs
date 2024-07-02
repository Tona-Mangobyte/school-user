using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IRegisterServices
    {
        Task<AddUserResponseDto?> CreateUserService(AddUserRequestDto addUserRequestDto, string? tokenHeader);
        int CalculateAge(DateTime dateOfBirth);
    }
}