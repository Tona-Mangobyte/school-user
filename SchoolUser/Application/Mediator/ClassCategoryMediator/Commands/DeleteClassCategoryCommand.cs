using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Commands
{
    public record DeleteClassCategoryCommand(Guid id) : IRequest<bool>;
}