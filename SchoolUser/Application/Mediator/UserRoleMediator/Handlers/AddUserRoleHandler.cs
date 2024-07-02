using MediatR;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.UserRoleMediator.Commands;
using SchoolUser.Domain.Interfaces.Repositories;

namespace SchoolUser.Application.Mediator.UserRoleMediator.Handlers;

public class AddUserRoleHandler : IRequestHandler<AddUserRoleCommand, UserRole>
{
    private readonly IUserRoleRepository _userRoleRepository;

    public AddUserRoleHandler(IUserRoleRepository userRoleRepository)
    {
        _userRoleRepository = userRoleRepository;
    }

    public async Task<UserRole> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
    {
        return await _userRoleRepository.CreateAsync(request.UserRole);
    }
}
