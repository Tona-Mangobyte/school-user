using SchoolUser.Application.Constants.Interfaces;

namespace SchoolUser.Contract.Constants.Main
{
    public class ValidationConstants : IValidationConstants
    {
        public List<string> ValidPositions { get; } = new List<string> { "admin", "teacher", "student" };
        public List<string> ValidGenders { get; } = new List<string> { "male", "female" };
        public List<string> ValidServiceStatuses { get; } = new List<string> { "permanent", "contract", "internship" };
    }
}