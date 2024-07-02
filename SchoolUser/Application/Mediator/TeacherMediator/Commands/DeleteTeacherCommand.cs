using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Commands
{
    public record DeleteTeacherCommand(Guid id) : IRequest<bool>;
}