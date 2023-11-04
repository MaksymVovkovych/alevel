namespace EntityFrameworkFirst.Applicalion.DTOs
{
    public class SchoolDto
    {
        public Guid Id { get; set; }
        public required string CaptionOfSchool { get; set; }
        public required string Address { get; set; }
    }
}
