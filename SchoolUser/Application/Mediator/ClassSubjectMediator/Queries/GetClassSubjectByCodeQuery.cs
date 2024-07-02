using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Queries
{
    public record GetClassSubjectByCodeQuery(string Code) : IRequest<ClassSubject?>;
}