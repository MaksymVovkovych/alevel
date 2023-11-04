using EntityFrameworkFirst.Domain.Interfaces;
using EntityFrameworkFirst.Infrastructure.Context;

namespace EntityFrameworkFirst.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private EFContext _context;

        public UnitOfWork(EFContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
