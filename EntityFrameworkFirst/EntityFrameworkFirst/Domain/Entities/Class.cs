namespace EntityFrameworkFirst.Domain.Entities
{
    public class Class
    {
        public Guid Id { get; set; }
        public required int ClassNumber { get; set; }
        public required int Capacity { get; set; }

        public Guid? SchoolId { get; set; }
        public School? School { get; set; }

        public Guid? PersonalId { get; set; }
        public StaffMember? Personal { get; set; }


    }
}
