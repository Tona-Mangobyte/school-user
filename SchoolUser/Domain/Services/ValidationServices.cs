using SchoolUser.Application.Constants.Interfaces;
using SchoolUser.Domain.Interfaces.Services;

namespace SchoolUser.Domain.Services
{
    public class ValidationServices : IValidationServices
    {
        private readonly IValidationConstants _validationConstants;

        public ValidationServices(IValidationConstants validationConstants)
        {
            _validationConstants = validationConstants;
        }

        public bool BeAValidDate(DateTime date)
        {
            return date.Year < DateTime.Now.Year;
        }

        public bool IsGenderValid(string gender)
        {
            var validGenders = _validationConstants.ValidGenders;
            string lowerCaseGender = gender.ToLower();
            return validGenders.Contains(lowerCaseGender);
        }

        public bool isPositionValid(string position)
        {
            var validPositions = _validationConstants.ValidPositions;
            string lowerCasePosition = position.ToLower();
            return validPositions.Contains(lowerCasePosition);
        }

        public bool isServiceStatusValid(string status)
        {
            var validStatuses = _validationConstants.ValidServiceStatuses;
            string lowerCaseStatus = status.ToLower();
            return validStatuses.Contains(lowerCaseStatus);
        }

        public bool BeValidPassword(string password)
        {
            return password.Any(char.IsLetter) &&
                   password.Any(char.IsDigit) &&
                   password.Any("!@#$%^&*_-.".Contains);
        }
    }
}