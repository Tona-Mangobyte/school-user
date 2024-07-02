using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands
{
    public record DeleteClassSubjectStudentCommand(Guid id) : IRequest<bool>;
}