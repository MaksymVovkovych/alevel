using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using EntityFrameworkFirst.Infrastructure.Repositories;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IRepositoryClass> _repositoryClass;
        private readonly Lazy<IRepositorySchool> _schoolRepository;
        private readonly Lazy<IRepositoryStaffMember> _staffMemberRepository;
        private readonly Lazy<IRepositoryService> _serviceRepository;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(EFContext efContext)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(efContext));
            _repositoryClass = new Lazy<IRepositoryClass>(() => new RepositoryClass(efContext));
            _schoolRepository = new Lazy<IRepositorySchool>(() => new RepositorySchool(efContext));
            _staffMemberRepository = new Lazy<IRepositoryStaffMember>(() => new RepositoryStaffMember(efContext));
            _serviceRepository = new Lazy<IRepositoryService>(() => new RepositoryService(efContext));

        }

        public IRepositoryClass RepositoryClass => _repositoryClass.Value;

        public IRepositorySchool RepositorySchool => _schoolRepository.Value;

        public IRepositoryStaffMember RepositoryStaffMember => _staffMemberRepository.Value;

        public IRepositoryService RepositoryService => _serviceRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}
