using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Commands
{
    public record AddTeacherCommand (Teacher Teacher) : IRequest<Teacher>;
}