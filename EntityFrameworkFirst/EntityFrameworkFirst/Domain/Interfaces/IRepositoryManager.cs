namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryManager
    {
        public IRepositoryClass RepositoryClass { get; }
        public IRepositorySchool RepositorySchool { get; }
        public IRepositoryStaffMember RepositoryStaffMember { get; }
        public IRepositoryService RepositoryService { get; }
        public IUnitOfWork UnitOfWork { get; }
    }
}
