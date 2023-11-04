namespace EntityFrameworkFirst.Applicalion.DTOs
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Email { get; set; }
    }
}
