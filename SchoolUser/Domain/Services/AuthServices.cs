using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Application.Mediator.UserMediator.Commands;
using SchoolUser.Application.Mediator.UserMediator.Queries;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SchoolUser.Application.Constants.Interfaces;
using Newtonsoft.Json;

namespace SchoolUser.Domain.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        private readonly IPasswordServices _passwordServices;
        private readonly ITokenServices _tokenServices;
        private readonly IConfiguration _configuration;
        private readonly string _pepper;
        private readonly int _iteration;
        private readonly IReturnValueConstants _returnValueConstants;

        public AuthServices(IMapper mapper, ISender sender, IPasswordServices passwordServices, ITokenServices tokenServices, IConfiguration configuration, IReturnValueConstants returnValueConstants)
        {
            _mapper = mapper;
            _sender = sender;
            _passwordServices = passwordServices;
            _tokenServices = tokenServices;
            _configuration = configuration;
            _pepper = _configuration.GetValue<string>("Password:Pepper")!;
            _iteration = _configuration.GetValue<int>("Password:Iteration");
            _returnValueConstants = returnValueConstants;
        }

        public async Task<LoginResponseDto?> LoginService(LoginRequestDto loginRequestDto)
        {
            var existingUser = await _sender.Send(new GetUserByEmailQuery(loginRequestDto.EmailAddress));

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "The account"));
            }

            if (!existingUser.IsConfirmedEmail)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ACCOUNT_NOT_VERIRIED));
            }

            var passwordHash = _passwordServices.CreatePasswordHashService(loginRequestDto.Password, existingUser.PasswordSalt, _pepper, _iteration);

            if (existingUser.PasswordHash != passwordHash)
            {
                throw new BusinessRuleException("Wrong Password.");
            }

            (existingUser.AccessToken, existingUser.TokenExpiration) = await _tokenServices.CreateJwtTokenService(existingUser);
            existingUser.RefreshToken = Guid.NewGuid().ToString();

            var userWithUpdatedToken = await _sender.Send(new UpdateTokenCommand(existingUser));

            if (userWithUpdatedToken == null)
            {
                throw new BusinessRuleException("Login failed");
            }

            var response = _mapper.Map<LoginResponseDto>(userWithUpdatedToken);
            return response;
        }

        public async Task<string> LogoutService(Guid id)
        {
            var existingUser = await _sender.Send(new GetUserByIdQuery(id));

            var existingUserJson = JsonConvert.SerializeObject(existingUser);
            Console.WriteLine(existingUserJson);

            if (existingUser == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "The account"));
            }

            Console.WriteLine("CONTINUE");

            existingUser.AccessToken = null;
            existingUser.RefreshToken = null;
            existingUser.TokenExpiration = DateTime.UtcNow.ToLocalTime();

            var existingUserJson2 = JsonConvert.SerializeObject(existingUser);
            Console.WriteLine(existingUserJson2);

            var userWithUpdatedToken = await _sender.Send(new UpdateTokenCommand(existingUser));

            if (userWithUpdatedToken == null)
            {
                throw new BusinessRuleException("Logout failed");
            }

            return "Logout Successful";
        }
    }
}