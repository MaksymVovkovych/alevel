using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;
using EntityFrameworkFirst.Infrastructure.Repositories;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IRepositoryClass> _repositoryClass;
        private readonly Lazy<IRepositorySchool> _schoolRepository;
        private readonly Lazy<IRepositoryStudent> _studentRepository;
        private readonly Lazy<IRepositorySubject> _subjectRepository;
        private readonly Lazy<IRepositoryTeacher> _teacherRepository;
        private readonly Lazy<IUnitOfWork> _unitOfWork;

        public RepositoryManager(EFContext efContext)
        {
            _unitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(efContext));
            _teacherRepository = new Lazy<IRepositoryTeacher>(() => new RepositoryTeacher(efContext));
            _repositoryClass = new Lazy<IRepositoryClass>(() => new RepositoryClass(efContext));
            _schoolRepository = new Lazy<IRepositorySchool>(() => new RepositorySchool(efContext));
            _studentRepository = new Lazy<IRepositoryStudent>(() => new RepositoryStudent(efContext));
            _subjectRepository = new Lazy<IRepositorySubject>(() => new RepositorySubject(efContext));

        }

        public IRepositoryClass RepositoryClass => _repositoryClass.Value;

        public IRepositorySchool RepositorySchool => _schoolRepository.Value;

        public IRepositoryStudent RepositoryStudent => _studentRepository.Value;

        public IRepositorySubject RepositorySubject => _subjectRepository.Value;

        public IRepositoryTeacher RepositoryTeacher => _teacherRepository.Value;

        public IUnitOfWork UnitOfWork => _unitOfWork.Value;
    }
}
