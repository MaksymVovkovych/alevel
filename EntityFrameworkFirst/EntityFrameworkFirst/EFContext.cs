using EntityFrameworkFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkFirst
{
    public class EFContext : DbContext
    {
        public DbSet<User> Users { get; private set; }
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Surname).IsRequired();

            modelBuilder.Entity<User>().Property(x => x.Birthday)
                .HasConversion(new ValueConverter<DateOnly?, DateTime?>(
                    x => x.HasValue ? x.Value.ToDateTime(TimeOnly.MinValue) : null,
                    y => y.HasValue ? DateOnly.FromDateTime(y.Value):null));
        }

    }
}
