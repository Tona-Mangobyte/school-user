using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Queries
{
    public record GetTeacherByIdQuery(Guid id) : IRequest<Teacher>;
}