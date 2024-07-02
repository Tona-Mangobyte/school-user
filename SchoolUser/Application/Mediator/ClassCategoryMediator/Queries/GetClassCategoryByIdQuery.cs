using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Queries
{
    public record GetClassCategoryByIdQuery(Guid id) : IRequest<ClassCategory?>;
}