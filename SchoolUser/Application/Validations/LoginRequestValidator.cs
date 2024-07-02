using FluentValidation;

namespace SchoolUser.Application.Validations;

public class LoginRequestValidator : AbstractValidator<Application.DTOs.LoginRequestDto>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .Length(8, 16).WithMessage("Password must be between 8 and 16 characters");
    }
}
