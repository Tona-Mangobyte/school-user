using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.SubjectMediator.Commands
{
    public record AddSubjectCommand (Subject Subject) : IRequest<Subject>;
}