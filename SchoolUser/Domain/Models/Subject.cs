using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SchoolUser.Domain.Models
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        #region Subject - ClassCategory
        [JsonIgnore]
        public List<ClassSubject>? ClassSubjects { get; set; }

        [NotMapped]
        public List<ClassCategory>? ClassCategories { get; set; }
        #endregion

        [NotMapped]
        public List<Teacher>? Teachers { get; set; }
    }
}