using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkFirst.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public required int ClassNumber { get; set; }

        
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; }

        public Guid SchoolId { get; set; }
        public School? School { get; set; }

        public ICollection<Student>? Students { get; set; }


    }
}
