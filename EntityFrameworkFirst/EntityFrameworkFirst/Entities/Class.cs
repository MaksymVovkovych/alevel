namespace EntityFrameworkFirst.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public required string ClassNumber { get; set; }

        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }
        public ICollection<Student>? Students { get; set; }

    }
}
