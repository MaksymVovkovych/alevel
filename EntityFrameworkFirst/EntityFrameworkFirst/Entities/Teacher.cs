namespace EntityFrameworkFirst.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public required string Name { get;  set; }
        public required string Surname { get;  set; }
        public int Age { get; set; }

        public Guid SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public Guid SchoolId { get; set; }
        public School? School { get; set; }

        public  Class? Class { get; set; }

        public ICollection<Student>? Students { get; set; }


    }
}
