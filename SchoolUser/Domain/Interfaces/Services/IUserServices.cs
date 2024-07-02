using SchoolUser.Application.DTOs;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<GetUserResponseDto>> GetAllUsersService();
        Task<PaginatedUsersResponseDto> GetPaginatedUsersService(int pageNumber, int pageSize, string? roleTitle);
        Task<GetUserResponseDto> GetUserByIdService(Guid id);
        Task<string> UpdateUserService(Guid id, GetUserRequestDto getUserDto);
        Task<string> DeleteUserService(Guid id);
        Task<string> VerifyAccountService(VerifyAccountDto verifyAccountDto);
        Task<string> ChangePasswordService(ChangePasswordDto changePasswordDto);
        Task<string> ResetPasswordService(ResetPasswordDto resetPasswordDto);
    }
}