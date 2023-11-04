using EntityFrameworkFirst.Domain.Entities;

namespace EntityFrameworkFirst.Domain.Interfaces
{
    public interface IRepositoryClass
    {
        Task CreateClassAsync(Class @class);
        Task UpdateClassAsync(Class @class);
        Task DeleteClassAsync(Class @class);
        Task<Class> GetClassAsync(Guid classId);
        Task<IReadOnlyCollection<Class>> GetAllClassesAsync();


    }
}
