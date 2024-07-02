using FluentValidation;

namespace SchoolUser.Application.Validations;

public class ResetPasswordValidator : AbstractValidator<Application.DTOs.ResetPasswordDto>
{
    public ResetPasswordValidator()
    {
        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid email address.");
    }
}
