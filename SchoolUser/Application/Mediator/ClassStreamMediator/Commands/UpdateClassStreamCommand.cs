using SchoolUser.Domain.Models;
using MediatR;

namespace SchoolUser.Application.Mediator.StreamMediator.Commands
{
    public record UpdateClassStreamCommand(ClassStream ClassStream) : IRequest<bool>;
}