using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Queries
{
    public record GetStudentByUserIdQuery(Guid UserId) : IRequest<Student?>;
}