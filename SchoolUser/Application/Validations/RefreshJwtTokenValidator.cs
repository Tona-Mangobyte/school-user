using FluentValidation;

namespace SchoolUser.Application.Validations;

public class RefreshJwtTokenValidator : AbstractValidator<Application.DTOs.RefreshJwtTokenDto>
{
    public RefreshJwtTokenValidator()
    {
        RuleFor(x => x.EmailAddress)
            .NotEmpty().WithMessage("Email Address is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage("Refresh Token is required");
    }

}
