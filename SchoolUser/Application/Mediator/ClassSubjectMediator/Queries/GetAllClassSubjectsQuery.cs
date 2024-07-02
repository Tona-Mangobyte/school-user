using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Queries
{
    public record GetAllClassSubjectsQuery () : IRequest<IEnumerable<ClassSubject>>;
}