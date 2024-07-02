using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Commands
{
    public record DeleteClassSubjectCommand (Guid id) : IRequest<bool>;
}