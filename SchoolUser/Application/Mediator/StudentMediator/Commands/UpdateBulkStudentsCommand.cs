using MediatR;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Application.Mediator.StudentMediator.Commands
{
    public record UpdateBulkStudentsCommand (UpdateStudentsDto UpdateStudentsDto) : IRequest<bool>;
}