using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassCategoryMediator.Queries;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Domain.Services
{
    public class ClassSubjectServices : IClassSubjectServices
    {
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "ClassSubject";

        public ClassSubjectServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<ClassSubject>> GetAllService()
        {
            return await _sender.Send(new GetAllClassSubjectsQuery());
        }

        public async Task<ClassSubject?> GetByIdService(Guid id)
        {
            var result = await _sender.Send(new GetClassSubjectByIdQuery(id));

            if (result == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            return result;
        }

        public async Task<ClassSubject?> CreateService(ClassSubjectDto ClassSubjectDto)
        {
            var classCategory = await _sender.Send(new GetClassCategoryByIdQuery(ClassSubjectDto.ClassCategoryId));
            var subject = await _sender.Send(new GetSubjectByIdQuery(ClassSubjectDto.SubjectId));

            if (classCategory == null || subject == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, EntityName));
            }

            ClassSubjectDto.Code = $"{classCategory!.Code}-{subject!.Code}";

            var existing = await _sender.Send(new GetClassSubjectByCodeQuery(ClassSubjectDto.Code));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"{ClassSubjectDto.Code}"));
            }

            var newObj = new ClassSubject()
            {
                Id = Guid.NewGuid(),
                ClassCategoryId = ClassSubjectDto.ClassCategoryId,
                SubjectId = ClassSubjectDto.SubjectId,
                Code = ClassSubjectDto.Code,
                AcademicYear = DateTime.Now.Year.ToString()
            };

            return await _sender.Send(new AddClassSubjectCommand(newObj));
        }

        public async Task<string> UpdateService(Guid id, ClassSubjectDto ClassSubjectDto)
        {
            var existing = await _sender.Send(new GetClassSubjectByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            var classCategory = await _sender.Send(new GetClassCategoryByIdQuery(ClassSubjectDto.ClassCategoryId));
            var subject = await _sender.Send(new GetSubjectByIdQuery(ClassSubjectDto.SubjectId));

            if (classCategory == null || subject == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            if (existing.Code != ClassSubjectDto.Code ||
            existing.ClassCategoryId != ClassSubjectDto.ClassCategoryId ||
            existing.SubjectId != ClassSubjectDto.SubjectId)
            {
                existing.Code = ClassSubjectDto.Code!;
                existing.ClassCategoryId = ClassSubjectDto.ClassCategoryId;
                existing.SubjectId = ClassSubjectDto.SubjectId;

                var result = await _sender.Send(new UpdateClassSubjectCommand(existing));

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
            var result = await _sender.Send(new DeleteClassSubjectCommand(id));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_DELETE, EntityName);
        }
    }
}