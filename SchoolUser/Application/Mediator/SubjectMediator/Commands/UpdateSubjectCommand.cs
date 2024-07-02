using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Commands
{
    public record UpdateSubjectCommand(Subject Subject) : IRequest<bool>;
}