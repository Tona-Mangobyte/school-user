using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Commands
{
    public record DeleteStudentCommand (Guid id) : IRequest<bool>;
}