using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace EntityFrameworkFirst.Infrastructure.Context
{
    internal class EFDbContextFactory : IDesignTimeDbContextFactory<EFContext>
    {

        private static string? _connectionString;
        public EFContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public EFContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                LoadConnection();
            }

            var builder = new DbContextOptionsBuilder<EFContext>();
            builder.UseSqlServer(_connectionString);

            return new EFContext(builder.Options);
        }

        private static void LoadConnection()
        {
            var builder = new ConfigurationBuilder();

            builder
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<EFDbContextFactory>();

            var configuration = builder.Build();

            _connectionString = configuration.GetConnectionString(nameof(EFContext));
        }


    }
}
