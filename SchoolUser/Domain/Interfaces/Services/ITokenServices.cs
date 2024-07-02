using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Interfaces.Services
{
    public interface ITokenServices
    {
        Task<(string, DateTime)> CreateJwtTokenService(User user);
        string CreateVerificationTokenService(int otpLength);
        Task<string?> RefreshJwtTokenService(Guid id, RefreshJwtTokenDto refreshJwtTokenDto);
    }
}