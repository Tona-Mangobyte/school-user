using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands
{
    public record DeleteClassSubjectTeacherCommand(Guid id) : IRequest<bool>;
}