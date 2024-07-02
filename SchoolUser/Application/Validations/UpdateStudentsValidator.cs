using FluentValidation;
using SchoolUser.Application.DTOs;

namespace SchoolUser.Application.Validations
{
    public class UpdateStudentsDtoValidator : AbstractValidator<UpdateStudentsDto>
    {
        public UpdateStudentsDtoValidator()
        {
            RuleFor(x => x.StudentIds).NotEmpty().WithMessage("StudentIds is required");
            RuleFor(x => x.EntranceYear).NotEmpty().WithMessage("EntranceYear is required");
            RuleFor(x => x.EstimatedExitYear).NotEmpty().WithMessage("EstimatedExitYear is required");
            RuleFor(x => x.RealExitYear).NotEmpty().WithMessage("RealExitYear is required");
            RuleFor(x => x.ExitReason).NotEmpty().WithMessage("ExitReason is required");
            RuleFor(x => x.ClassCategoryId).NotNull().WithMessage("ClassCategoryId is required");
        }
    }
}