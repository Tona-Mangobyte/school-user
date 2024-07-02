using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class UserRole
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public User? User { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public Role? Role { get; set; }
        public Guid RoleId { get; set; }
    }
}