using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Queries
{
    public record GetStudentByIdQuery (Guid id) : IRequest<Student>;
}