using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.StreamMediator.Commands;
using SchoolUser.Application.Mediator.StreamMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Domain.Services
{
    public class ClassStreamServices : IClassStreamServices
    {
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "ClassStream";

        public ClassStreamServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassStream>> GetAllService()
        {
            return await _sender.Send(new GetAllClassStreamsQuery());
        }

        public async Task<ClassStream?> GetByIdService(Guid id)
        {
            var result = await _sender.Send(new GetClassStreamByIdQuery(id));

            if (result == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            return result;
        }

        public async Task<ClassStream?> CreateService(ClassStreamDto ClassStreamDto)
        {
            var existing = await _sender.Send(new GetClassStreamByNameQuery(ClassStreamDto.Name));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"{ClassStreamDto.Name}"));
            }

            var newObj = new ClassStream()
            {
                Id = Guid.NewGuid(),
                Name = ClassStreamDto.Name,
                Code = ClassStreamDto.Code
            };

            return await _sender.Send(new AddClassStreamCommand(newObj));
        }

        public async Task<string> UpdateService(Guid id, ClassStreamDto ClassStreamDto)
        {
            var existing = await _sender.Send(new GetClassStreamByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (existing.Name != ClassStreamDto.Name || existing.Code != ClassStreamDto.Code)
            {
                existing.Name = ClassStreamDto.Name;
                existing.Code = ClassStreamDto.Code;

                var result = await _sender.Send(new UpdateClassStreamCommand(existing));

                if (!result)
                {
                    throw new Exception(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
                }
            }
            else
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.NO_CHANGES_MADE, EntityName));
            }


            return string.Format(_returnValueConstants.SUCCESSFUL_UPDATE, EntityName);
        }

        public async Task<string> DeleteService(Guid id)
        {
            var result = await _sender.Send(new DeleteClassStreamCommand(id));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_DELETE, EntityName);
        }
    }
}