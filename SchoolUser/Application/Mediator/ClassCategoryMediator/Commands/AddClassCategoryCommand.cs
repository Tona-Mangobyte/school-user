using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Commands
{
    public record AddClassCategoryCommand(ClassCategory ClassCategory) : IRequest<ClassCategory>;
}