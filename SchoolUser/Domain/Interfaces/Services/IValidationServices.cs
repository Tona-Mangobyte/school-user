namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IValidationServices
    {
        bool BeAValidDate(DateTime date);
        bool IsGenderValid(string gender);
        bool isPositionValid(string position);
        bool isServiceStatusValid(string status);
        bool BeValidPassword(string password);
    }
}