using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Commands
{
    public record UpdateStudentCommand (Student Student) : IRequest<bool>;
}