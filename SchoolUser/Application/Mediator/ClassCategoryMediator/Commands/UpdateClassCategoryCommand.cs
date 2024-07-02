using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Commands
{
    public record UpdateClassCategoryCommand(ClassCategory ClassCategory) : IRequest<bool>;
}