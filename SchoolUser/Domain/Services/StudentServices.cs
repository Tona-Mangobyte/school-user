using AutoMapper;
using MediatR;
using SchoolUser.Application.DTOs;
using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Services;
using SchoolUser.Application.ErrorHandlings;
using SchoolUser.Domain.Models;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectStudentMediator.Queries;
using SchoolUser.Application.Mediator.StudentMediator.Commands;
using SchoolUser.Application.Mediator.ClassSubjectMediator.Queries;

namespace SchoolUser.Domain.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;
        private readonly IReturnValueConstants _returnValueConstants;
        private readonly string EntityName = "Student";
        private readonly IClassCategoryServices _classCategoryServices;

        public StudentServices(ISender sender, IMapper mapper, IReturnValueConstants returnValueConstants, IClassCategoryServices classCategoryServices)
        {
            _sender = sender;
            _mapper = mapper;
            _returnValueConstants = returnValueConstants;
            _classCategoryServices = classCategoryServices;
        }

        public async Task<bool> CreateStudent(StudentRequestDto studentRequestDto)
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                EntranceYear = studentRequestDto.EntranceYear!,
                EstimatedExitYear = studentRequestDto.EstimatedExitYear!,
                RealExitYear = studentRequestDto.RealExitYear,
                ExitReason = studentRequestDto.ExitReason,
                UserId = studentRequestDto.UserId,
                ClassCategoryId = studentRequestDto.ClassCategoryId!
            };

            var validClassSubject = await _sender.Send(new GetClassSubjectListByClassCategoryIdQuery((Guid)student.ClassCategoryId));
            var validClassSubjectIds = validClassSubject.Select(cs => cs.Id).ToList();
            List<Guid>? selectedClassSubjectIds = new List<Guid>();

            if (studentRequestDto.ClassSubjectIds != null && studentRequestDto.ClassSubjectIds.Count > 0 && validClassSubjectIds != null && validClassSubjectIds.Count > 0)
            {
                selectedClassSubjectIds = studentRequestDto.ClassSubjectIds.Intersect(validClassSubjectIds).ToList();
            }

            var createdStudent = await _sender.Send(new AddStudentCommand(student));

            var createdClassSubjectStudent = false;
            createdClassSubjectStudent = await CreateClassSubjectStudent(selectedClassSubjectIds!, createdStudent.Id);

            if (createdStudent == null || !createdClassSubjectStudent)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, EntityName));
            }

            return true;
        }

        private async Task<bool> CreateClassSubjectStudent(List<Guid> classSubjectIds, Guid studentId)
        {
            foreach (var id in classSubjectIds!)
            {
                ClassSubjectStudent classSubjectStudent = new ClassSubjectStudent()
                {
                    Id = Guid.NewGuid(),
                    ClassSubjectId = id,
                    StudentId = studentId
                };

                var createdClassSubjectStudent = await _sender.Send(new AddClassSubjectStudentCommand(classSubjectStudent));
                Console.WriteLine($"CSS {createdClassSubjectStudent.Id}");

                if (createdClassSubjectStudent == null)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_CREATE, EntityName));
                }
            }

            return true;
        }

        public async Task<bool> UpdateStudent(GetUserRequestDto getUserDto, Student? student)
        {
            if (student == null)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.ITEM_DOES_NOT_EXIST, EntityName));
            }

            if (student.EntranceYear != getUserDto.EntranceYear ||
            student.EstimatedExitYear != getUserDto.EstimatedExitYear ||
            student.RealExitYear != getUserDto.RealExitYear ||
            student.ExitReason != getUserDto.ExitReason ||
            student.ClassCategoryId != getUserDto.ClassCategoryId)
            {
                var toUpdate = _mapper.Map<Student>(getUserDto);
                toUpdate.Id = student.Id;
                toUpdate.UserId = student.UserId;

                var updatedStudent = await _sender.Send(new UpdateStudentCommand(toUpdate));
                var updatedClassSubjectStudent = false;

                if (getUserDto.ClassSubjectIds != null && getUserDto.ClassSubjectIds.Count > 0)
                {
                    updatedClassSubjectStudent = await UpdateClassSubjectStudent(getUserDto.ClassSubjectIds, toUpdate.Id);
                }

                if (!updatedStudent || !updatedClassSubjectStudent)
                {
                    throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
                }

                return true;
            }

            return false;
        }

        private async Task<bool> UpdateClassSubjectStudent(List<Guid> newClassSubjectIds, Guid studentId)
        {
            var existingClassSubjectStudents = await _sender.Send(new GetClassSubjectStudentListByStudentIdQuery(studentId));
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
                        deletedResult = await _sender.Send(new DeleteClassSubjectStudentCommand(css.Id));
                    }
                }
            }

            if (toCreateClassSubjectIds != null && toCreateClassSubjectIds.Count > 0)
            {
                createdResult = await CreateClassSubjectStudent(toCreateClassSubjectIds, studentId);
            }

            if (!deletedResult && !createdResult)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            return true;
        }

        public async Task<string> UpdateStudentInBulkService(UpdateStudentsDto updateStudentsDto)
        {
            if (updateStudentsDto.ClassCategoryId != null)
            {
                await _classCategoryServices.CheckIdValidityService((Guid)updateStudentsDto.ClassCategoryId);
            }

            var result = await _sender.Send(new UpdateBulkStudentsCommand(updateStudentsDto));

            if (!result)
            {
                throw new BusinessRuleException(string.Format(_returnValueConstants.FAILED_UPDATE, EntityName));
            }

            return string.Format(_returnValueConstants.SUCCESSFUL_UPDATE, $"{EntityName}s");
        }

    }
}