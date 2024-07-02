using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public bool IsConfirmedEmail { get; set; }
        public string MobileNumber { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public string VerificationNumber { get; set; }
        public DateTime VerificationExpiration { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime TokenExpiration { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedAt { get; set; }

        [NotMapped]
        public List<string>? Roles { get; set; }

        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }

        [NotMapped]
        public Student? Student { get; set; }

        [NotMapped]
        public Teacher? Teacher { get; set; }
    }
}