using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Queries
{
    public record GetTeacherByUserIdQuery(Guid userId) : IRequest<Teacher?>;
}