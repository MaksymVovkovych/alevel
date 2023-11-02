namespace EntityFrameworkFirst.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }


        public int ClassId { get; set; }
        public required Class Class { get; set; }

        public int TeacherId { get; set; }
        public required Teacher Teacher { get; set; }

        public ICollection<Subject>? Subjects { get; set; }
    }
}
