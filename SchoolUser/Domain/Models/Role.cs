using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public List<UserRole>? UserRoles { get; set; }
    }
}