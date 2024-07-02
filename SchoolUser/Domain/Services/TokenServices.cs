using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Domain.Services
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly Random random = new Random();
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        public TokenServices(IConfiguration configuration, ISender sender, IReturnValueConstants returnValueConstants)
        {
            _configuration = configuration;
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }
        public async Task<(string, DateTime)> CreateJwtTokenService(Models.User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, user.FullName),
                new Claim(ClaimTypes.Email, user.EmailAddress)
            };

            user.Roles!.ForEach((role) =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(_configuration.GetValue<int>("Jwt:Expires")),
                signingCredentials: credentials);

            var accessToken = await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
            var tokenExpiration = token.ValidTo.AddHours(8);

            return (accessToken, tokenExpiration);
        }

        public string CreateVerificationTokenService(int otpLength)
        {

            const string chars = "0123456789";
            char[] otp = new char[otpLength];

            for (int i = 0; i < otpLength; i++)
            {
                otp[i] = chars[random.Next(chars.Length)];
            }

            return new string(otp);
        }

        public async Task<string?> RefreshJwtTokenService(Guid id, RefreshJwtTokenDto refreshJwtTokenDto)
        {
            var existingUser = await _sender.Send(new GetUserByEmailQuery(refreshJwtTokenDto.EmailAddress));
            double latestReset = 15.0;
            double earliestReset = 45.0;

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "The account"));
            }

            if (existingUser.RefreshToken != refreshJwtTokenDto.RefreshToken)
            {
                throw new BusinessRuleException("Session Expired! Please re-login");
            }

            var TimeInterval = existingUser.TokenExpiration - DateTime.UtcNow.ToLocalTime();
            double timeInSeconds = TimeInterval.TotalSeconds;

            if (timeInSeconds < latestReset)
            {
                throw new BusinessRuleException("Session Expired! Please re-login");
            }

            if (timeInSeconds < earliestReset && timeInSeconds > latestReset)
            {
                (existingUser.AccessToken, existingUser.TokenExpiration) = await CreateJwtTokenService(existingUser);
                var userWithUpdatedToken = await _sender.Send(new UpdateTokenCommand(existingUser));

                if (userWithUpdatedToken == null)
                {
                    throw new BusinessRuleException("Token Refresh failed");
                }

                Console.WriteLine("RETURN NEW TOKEN");
                return userWithUpdatedToken.AccessToken;
            }

            Console.WriteLine("RETURN OLD TOKEN");
            return existingUser.AccessToken;
        }

    }
}