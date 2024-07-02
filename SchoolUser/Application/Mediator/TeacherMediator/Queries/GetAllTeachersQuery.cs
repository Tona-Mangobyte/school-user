using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Queries
{
    public record GetAllTeachersQuery () : IRequest<IEnumerable<Teacher>>;
}