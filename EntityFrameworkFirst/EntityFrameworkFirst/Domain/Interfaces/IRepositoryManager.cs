namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryManager
    {
        public IRepositoryClass RepositoryClass { get; }
        public IRepositorySchool RepositorySchool { get; }
        public IRepositoryStudent RepositoryStudent { get; }
        public IRepositorySubject RepositorySubject { get; }

        public IRepositoryTeacher RepositoryTeacher { get; }
        public IUnitOfWork UnitOfWork { get; }
    }
}
