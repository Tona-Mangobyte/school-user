using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Commands
{
    public record DeleteSubjectCommand (Guid id) : IRequest<bool>;
}