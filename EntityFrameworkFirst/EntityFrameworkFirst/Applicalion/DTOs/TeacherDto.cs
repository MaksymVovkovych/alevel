namespace EntityFrameworkFirst.Applicalion.DTOs
{
    public class TeacherDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public int Age { get; set; }
    }
}
