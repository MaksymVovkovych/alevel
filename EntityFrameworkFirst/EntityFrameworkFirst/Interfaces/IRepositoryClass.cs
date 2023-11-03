using EntityFrameworkFirst.Entities;

namespace EntityFrameworkFirst.Repositories
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
