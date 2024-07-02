using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.ClassCategoryMediator.Queries
{
    public record GetClassCategoryByCodeQuery(string Code) : IRequest<ClassCategory?>;
}