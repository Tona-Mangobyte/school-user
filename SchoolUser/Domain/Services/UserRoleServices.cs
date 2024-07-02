using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.UserRoleMediator.Commands;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Application.Interfaces.UnitOfWorks;
using SchoolUser.Application.ErrorHandlings;

namespace SchoolUser.Domain.Services
{
    public class UserRoleServices : IUserRoleServices
    {
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private const string EntityName = "UserRole";
        public UserRoleServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task CreateUserRoleService(Guid id, List<Role> roles)
        {
            bool createdUserRole = true;

            for (int i = 0; i < roles.Count; i++)
            {
                var userRole = new UserRole()
                {
                    Id = Guid.NewGuid(),
                    UserId = id,
                    RoleId = roles[i].Id
                };

                var result = await _sender.Send(new AddUserRoleCommand(userRole));

                if (result == null)
                {
                    createdUserRole = false;
                }
            }

            if (!createdUserRole)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, EntityName));
            }
        }
    }
}