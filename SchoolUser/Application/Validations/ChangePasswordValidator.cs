using FluentValidation;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Application.Validations;

public class ChangePasswordValidator : AbstractValidator<Application.DTOs.ChangePasswordDto>
{
    private readonly IValidationServices _validationServices;
    public ChangePasswordValidator(IValidationServices validationServices)
    {
        _validationServices = validationServices;

        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.OldPassword)
            .NotEmpty().WithMessage("Password is required")
            .Length(8, 16).WithMessage("Password must be between 8 and 16 characters");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("Password is required")
            .Length(8, 16).WithMessage("Password must be between 8 and 16 characters")
            .NotEqual(x => x.OldPassword).WithMessage("New Password should not match the Old Password")
            .Must(_validationServices.BeValidPassword).WithMessage("Password must be alphanumeric with special characters (!@#$%^&*_)");

        RuleFor(x => x.ConfirmNewPassword)
            .NotEmpty().WithMessage("Confirm Password is required")
            .Equal(x => x.NewPassword).WithMessage("Passwords do not match");

    }

}
