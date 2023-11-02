namespace EntityFrameworkFirst.Entities
{
    public class Subject
    {
        public int Id { get; set; }

        public required string SubjectName { get; set; }


        public ICollection<Student>? Students { get; set; }



    }
}
