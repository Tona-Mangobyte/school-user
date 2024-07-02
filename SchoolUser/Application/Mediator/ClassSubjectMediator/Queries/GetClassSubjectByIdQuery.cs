using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Queries
{
    public record GetClassSubjectByIdQuery (Guid id) : IRequest<ClassSubject>;
}