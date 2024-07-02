using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.BatchMediator.Queries;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Commands;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using SchoolUser.Application.Mediator.StreamMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Domain.Services
{
    public class ClassCategoryServices : IClassCategoryServices
    {
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "ClassCategory";

        public ClassCategoryServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassCategory>> GetAllService()
        {
            return await _sender.Send(new GetAllClassCategoriesQuery());
        }

        public async Task<ClassCategory?> GetByIdService(Guid id)
        {
            var result = await _sender.Send(new GetClassCategoryByIdQuery(id));

            if (result == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            return result;
        }

        public async Task<bool> CheckIdValidityService(Guid id)
        {
            var uniqueClassCategoryIds = await _sender.Send(new GetUniqueClassCategoryIdsQuery()) as List<Guid>;

            if (uniqueClassCategoryIds == null || !uniqueClassCategoryIds.Contains(id))
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, "ClassCategory"));
            }

            return true;
        }

        public async Task<ClassCategory?> CreateService(ClassCategoryDto ClassCategoryDto)
        {
            var batch = await _sender.Send(new GetBatchByIdQuery(ClassCategoryDto.BatchId));
            var ClassStream = await _sender.Send(new GetClassStreamByIdQuery(ClassCategoryDto.ClassStreamId));

            if (batch == null || ClassStream == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, EntityName));
            }

            ClassCategoryDto.Code = $"{batch!.Name}-{ClassStream!.Code}";

            var existing = await _sender.Send(new GetClassCategoryByCodeQuery(ClassCategoryDto.Code));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"{ClassCategoryDto.Code}"));
            }

            var newObj = new ClassCategory()
            {
                Id = Guid.NewGuid(),
                Code = ClassCategoryDto.Code,
                BatchId = ClassCategoryDto.BatchId,
                ClassStreamId = ClassCategoryDto.ClassStreamId,
            };

            return await _sender.Send(new AddClassCategoryCommand(newObj));
        }

        public async Task<string> UpdateService(Guid id, ClassCategoryDto ClassCategoryDto)
        {
            var existing = await _sender.Send(new GetClassCategoryByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            var batch = await _sender.Send(new GetBatchByIdQuery(ClassCategoryDto.BatchId));
            var ClassStream = await _sender.Send(new GetClassStreamByIdQuery(ClassCategoryDto.ClassStreamId));

            if (batch == null || ClassStream == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            if (existing.Code != ClassCategoryDto.Code ||
            existing.BatchId != ClassCategoryDto.BatchId ||
            existing.ClassStreamId != ClassCategoryDto.ClassStreamId)
            {
                existing.Code = ClassCategoryDto.Code!;
                existing.BatchId = ClassCategoryDto.BatchId;
                existing.ClassStreamId = ClassCategoryDto.ClassStreamId;

                var result = await _sender.Send(new UpdateClassCategoryCommand(existing));

                if (!result)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
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
            var result = await _sender.Send(new DeleteClassCategoryCommand(id));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_DELETE, EntityName);
        }
    }
}