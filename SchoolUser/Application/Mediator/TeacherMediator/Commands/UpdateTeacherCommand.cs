using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.TeacherMediator.Commands
{
    public record UpdateTeacherCommand (Teacher Teacher): IRequest<bool>;
}