namespace EntityFrameworkFirst.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }

        public required string SubjectName { get; set; }

        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Student>? Students { get; set; }



    }
}
