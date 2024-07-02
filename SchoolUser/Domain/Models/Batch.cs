using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolUser.Domain.Models
{
    public class Batch
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<ClassCategory>? ClassCategories { get; set; }

        [NotMapped]
        public List<ClassStream>? ClassStreams { get; set; }
    }
}