using FluentValidation;

namespace SchoolUser.Application.Validations;

public class AddRoleValidator : AbstractValidator<Application.DTOs.RoleDto>
{
    public AddRoleValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.");
    }

}
