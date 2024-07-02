using MediatR;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.ClassSubjectMediator.Queries
{
    public record GetClassSubjectListByClassCategoryIdQuery (Guid ClassCategoryId) : IRequest<IEnumerable<ClassSubject>>;
}