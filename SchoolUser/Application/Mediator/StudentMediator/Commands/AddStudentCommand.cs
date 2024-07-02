using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StudentMediator.Commands
{
    public record AddStudentCommand (Student Student) : IRequest<Student>;
}