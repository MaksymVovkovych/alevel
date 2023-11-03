namespace EntityFrameworkFirst.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string Email { get; set; }


        public Guid ClassId { get; set; }
        public  Class? Class { get; set; }

        public Guid TeacherId { get; set; }
        public  Teacher? Teacher { get; set; }

        public Guid SchoolId { get; set; }
        public  School? School { get; set; }

        public ICollection<Subject>? Subjects { get; set; }
    }
}
