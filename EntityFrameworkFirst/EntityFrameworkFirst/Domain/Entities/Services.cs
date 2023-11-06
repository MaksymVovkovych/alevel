namespace EntityFrameworkFirst.Domain.Entities
{
    public class Services
    {
        public Guid Id { get; set; }
        public required string ServiceName { get; set; }
        public required string TypeService { get; set; }
        public required string Description { get; set; }


        public ICollection<StaffMember>? Personal { get; set; }



    }
}
