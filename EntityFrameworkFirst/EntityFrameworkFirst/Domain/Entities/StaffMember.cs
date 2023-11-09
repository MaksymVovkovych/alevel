namespace EntityFrameworkFirst.Domain.Entities
{
    public class StaffMember
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }


        public Guid? ClassId { get; set; }
        public Class? Class { get; set; }

        public ICollection<Services>? Services { get; set; }
    }
}
