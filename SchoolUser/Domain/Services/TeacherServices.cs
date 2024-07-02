using AutoMapper;
using MediatR;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectTeacherMediator.Queries;
using SchoolUser.Application.Mediator.TeacherMediator.Commands;

namespace SchoolUser.Domain.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "Teacher";

        public TeacherServices(ISender sender, IMapper mapper, IReturnValueConstants returnValueConstants)
        {
            _sender = sender;
            _mapper = mapper;
            _returnValueConstants = returnValueConstants;
        }

        public async Task<bool> CreateTeacher(TeacherRequestDto teacherRequestDto)
        {
            var teacher = new Teacher()
            {
                Id = Guid.NewGuid(),
                ServiceStatus = teacherRequestDto.ServiceStatus!,
                IsAvailable = teacherRequestDto.IsAvailable,
                UserId = teacherRequestDto.UserId,
                ClassCategoryId = teacherRequestDto.ClassCategoryId
            };

            var createdTeacher = await _sender.Send(new AddTeacherCommand(teacher));
            var createdClassSubjectTeacher = false;

            if (teacherRequestDto.ClassSubjectIds != null && teacherRequestDto.ClassSubjectIds.Count > 0)
            {
                createdClassSubjectTeacher = await CreateClassSubjectTeacher(teacherRequestDto.ClassSubjectIds, createdTeacher.Id);
            }

            if (createdTeacher == null || !createdClassSubjectTeacher)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, "Teacher"));
            }

            return true;
        }

        private async Task<bool> CreateClassSubjectTeacher(List<Guid> classSubjectIds, Guid teacherId)
        {
            foreach (var id in classSubjectIds!)
            {
                ClassSubjectTeacher classSubjectTeacher = new ClassSubjectTeacher()
                {
                    Id = Guid.NewGuid(),
                    ClassSubjectId = id,
                    TeacherId = teacherId
                };

                var createdClassSubjectTeacher = await _sender.Send(new AddClassSubjectTeacherCommand(classSubjectTeacher));

                if (createdClassSubjectTeacher == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, "Teacher"));
                }
            }

            return true;
        }

        public async Task<bool> UpdateTeacher(GetUserRequestDto getUserDto, Teacher? teacher)
        {
            if (teacher == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (teacher.ServiceStatus != getUserDto.ServiceStatus ||
            teacher.IsAvailable != getUserDto.IsAvailable ||
            teacher.ClassCategoryId != getUserDto.ClassCategoryId)
            {
                var toUpdate = _mapper.Map<Teacher>(getUserDto);
                toUpdate.Id = teacher.Id;
                toUpdate.UserId = teacher.UserId;

                var updatedTeacher = await _sender.Send(new UpdateTeacherCommand(toUpdate));
                var updatedClassSubjectTeacher = false;

                if (getUserDto.ClassSubjectIds != null && getUserDto.ClassSubjectIds.Count > 0)
                {
                    updatedClassSubjectTeacher = await UpdateClassSubjectTeacher(getUserDto.ClassSubjectIds, toUpdate.Id);
                }

                if (!updatedTeacher || !updatedClassSubjectTeacher)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
                }

                return true;
            }

            return false;
        }

        private async Task<bool> UpdateClassSubjectTeacher(List<Guid> newClassSubjectIds, Guid teacherId)
        {
            var existingClassSubjectStudents = await _sender.Send(new GetListByTeacherIdQuery(teacherId));
            var existingClassSubjectIds = existingClassSubjectStudents.Select(c => c.ClassSubjectId).ToList();

            var toMaintainClassSubjectIds = existingClassSubjectIds.Intersect(newClassSubjectIds).ToList();
            var toDeleteClassSubjectIds = existingClassSubjectIds.Except(newClassSubjectIds).ToList();
            var toCreateClassSubjectIds = newClassSubjectIds.Except(existingClassSubjectIds).ToList();

            bool deletedResult = false;
            bool createdResult = false;

            if (toDeleteClassSubjectIds != null && toDeleteClassSubjectIds.Count > 0)
            {
                foreach (var css in existingClassSubjectStudents)
                {
                    if (toDeleteClassSubjectIds.Contains(css.ClassSubjectId))
                    {
                        deletedResult = await _sender.Send(new DeleteClassSubjectTeacherCommand(css.Id));
                    }
                }
            }

            if (toCreateClassSubjectIds != null && toCreateClassSubjectIds.Count > 0)
            {
                createdResult = await CreateClassSubjectTeacher(toCreateClassSubjectIds, teacherId);
            }

            if (!deletedResult && !createdResult)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            return true;
        }

    }
}