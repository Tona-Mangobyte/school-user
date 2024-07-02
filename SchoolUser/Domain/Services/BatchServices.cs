using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Commands;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Domain.Services
{
    public class BatchServices : IBatchServices
    {
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "Batch";

        public BatchServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Batch>> GetAllService()
        {
            return await _sender.Send(new GetAllBatchesQuery());
        }

        public async Task<Batch?> GetByIdService(Guid id)
        {
            var result = await _sender.Send(new GetBatchByIdQuery(id));

            if (result == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            return result;
        }

        public async Task<Batch?> CreateService(BatchDto batchDto)
        {
            var existing = await _sender.Send(new GetBatchByNameQuery(batchDto.Name));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"{batchDto.Name}"));
            }

            var newObj = new Batch()
            {
                Id = Guid.NewGuid(),
                Name = batchDto.Name,
            };

            return await _sender.Send(new AddBatchCommand(newObj));
        }

        public async Task<string> UpdateService(Guid id, BatchDto batchDto)
        {
            var existing = await _sender.Send(new GetBatchByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (existing.Name != batchDto.Name)
            {
                existing.Name = batchDto.Name;

                var result = await _sender.Send(new UpdateBatchCommand(existing));

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
            var result = await _sender.Send(new DeleteBatchCommand(id));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_DELETE, EntityName);
        }
    }
}