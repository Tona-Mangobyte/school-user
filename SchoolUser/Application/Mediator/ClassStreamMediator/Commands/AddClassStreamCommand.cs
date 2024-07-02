using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Commands
{
    public record AddClassStreamCommand(ClassStream ClassStream) : IRequest<ClassStream>;
}