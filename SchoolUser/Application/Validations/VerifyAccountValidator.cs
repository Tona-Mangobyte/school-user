using FluentValidation;

namespace SchoolUser.Application.Validations;

public class VerifyAccountValidator : AbstractValidator<Application.DTOs.VerifyAccountDto>
{
    public VerifyAccountValidator()
    {
        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.VerificationNumber)
            .NotEmpty().WithMessage("Verification Number is required")
            .Length(6).WithMessage("Verification Number must be exactly 6 characters");
    }
}
