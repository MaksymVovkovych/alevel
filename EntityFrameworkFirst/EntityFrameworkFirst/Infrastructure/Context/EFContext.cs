using EntityFrameworkFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkFirst.Infrastructure.Context
{
    public class EFContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }


        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
