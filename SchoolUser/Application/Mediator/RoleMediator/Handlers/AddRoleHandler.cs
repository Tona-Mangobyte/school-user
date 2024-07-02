using MediatR;
using SchoolUser.Domain.Interfaces.Repositories;
using SchoolUser.Application.Mediator.RoleMediator.Commands;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.RoleMediator.Handlers;

public class AddRoleHandler : IRequestHandler<AddRoleCommand, Role>
{
    private readonly IRoleRepository _roleRepository;

    public AddRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<Role> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        return await _roleRepository.CreateAsync(request.Role);
    }
}
