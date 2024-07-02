using FluentValidation;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Application.Validations;
public class GetUserValidator : AbstractValidator<Application.DTOs.GetUserRequestDto>
{
    private readonly IValidationServices _validationServices;
    public GetUserValidator(IValidationServices validationServices)
    {
        _validationServices = validationServices;

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full Name is required.");

        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile Number is required.")
            .Matches(@"^01[0-9]{8,9}$").WithMessage("Invalid mobile number.");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("Date of Birth is required.")
            .Must(x => _validationServices.BeAValidDate(x)).WithMessage("Invalid date");

        RuleFor(x => x.Gender)
            .NotEmpty().WithMessage("Gender is required.")
            .Must(x => _validationServices.IsGenderValid(x)).WithMessage("Invalid gender");

    }

}