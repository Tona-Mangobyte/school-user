namespace SchoolUser.Domain.Interfaces.Services
{
    public interface IPasswordServices
    {
        string CreatePasswordHashService(string password, string salt, string pepper, int iteration);
        string GenerateSaltService();
        string CreateRandomPasswordService();
    }
}