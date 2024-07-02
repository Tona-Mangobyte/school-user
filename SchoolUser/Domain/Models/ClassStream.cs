using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolUser.Domain.Models
{
    public class ClassStream
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public List<ClassCategory>? ClassCategories { get; set; }

        [NotMapped]
        public List<Batch>? Batches { get; set; }
    }
}