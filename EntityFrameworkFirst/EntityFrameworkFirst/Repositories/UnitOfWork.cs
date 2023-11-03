using EntityFrameworkFirst.Context;

namespace EntityFrameworkFirst.Repositories
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
