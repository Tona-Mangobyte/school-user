using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Queries
{
    public record GetAllStudentsQuery () : IRequest<IEnumerable<Student>>;
}