namespace EntityFrameworkFirst.Domain.Entities
{
    public class School
    {
        public Guid Id { get; set; }
        public required string CaptionOfSchool { get; set; }
        public required string Address { get; set; }

        public ICollection<Teacher>? Teachers { get; set; }
        public ICollection<Class>? Classes { get; set; }
        public ICollection<Student>? Students { get; set; }
    }
}
