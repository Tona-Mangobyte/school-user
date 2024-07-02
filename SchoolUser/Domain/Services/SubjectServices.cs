using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.SubjectMediator.Commands;
using SchoolUser.Application.Mediator.SubjectMediator.Queries;
using SchoolUser.Application.Mediator.TeacherMediator.Queries;
using MediatR;
using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Domain.Services
{
    public class SubjectServices : ISubjectServices
    {
        private readonly ISender _sender;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "Subject";

        public SubjectServices(ISender sender, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<IEnumerable<Subject>> GetAllService()
        {
            var listOfSubjects = await _sender.Send(new GetAllSubjectsQuery());

            foreach (var subject in listOfSubjects)
            {
                subject.Teachers = (List<Teacher>?)await _sender.Send(new GetTeacherListBySubjectIdQuery(subject.Id));
            }

            return listOfSubjects;
        }

        public async Task<Subject?> GetByIdService(Guid id)
        {
            var result = await _sender.Send(new GetSubjectByIdQuery(id));

            if (result == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            result.Teachers = (List<Teacher>?)await _sender.Send(new GetTeacherListBySubjectIdQuery(id));
            return result;
        }

        public async Task<Subject?> CreateService(SubjectDto SubjectDto)
        {
            var existing = await _sender.Send(new GetSubjectByNameQuery(SubjectDto.Name));

            if (existing != null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_ALREADY_EXIST, $"{SubjectDto.Name}"));
            }

            var newObj = new Subject()
            {
                Id = Guid.NewGuid(),
                Name = SubjectDto.Name,
                Code = SubjectDto.Code
            };

            return await _sender.Send(new AddSubjectCommand(newObj));
        }

        public async Task<string> UpdateService(Guid id, SubjectDto SubjectDto)
        {
            var existing = await _sender.Send(new GetSubjectByIdQuery(id));

            if (existing == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (existing.Name != SubjectDto.Name || existing.Code != SubjectDto.Code)
            {
                existing.Name = SubjectDto.Name;
                existing.Code = SubjectDto.Code;

                var result = await _sender.Send(new UpdateSubjectCommand(existing));

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
            var result = await _sender.Send(new DeleteSubjectCommand(id));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_DELETE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_DELETE, EntityName);
        }
    }
}