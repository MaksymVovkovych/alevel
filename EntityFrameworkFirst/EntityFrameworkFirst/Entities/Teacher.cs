namespace EntityFrameworkFirst.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public required string Name { get;  set; }
        public required string Surname { get;  set; }
        public int Age { get; set; }


        public int ClassId { get; set; }
        public required Class ClassTeacher { get; set; }
        public ICollection<Student>? Students { get; set; }


    }
}
