using Catalog.Host.Data.Entity;
using Catalog.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }
    
    public virtual DbSet<CatalogBrand> CatalogBrands { get; set; }
    public virtual DbSet<CatalogItem> CatalogItems { get; set; }
    public virtual DbSet<CatalogType> CatalogTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CatalogBrandConfigurations());
        modelBuilder.ApplyConfiguration(new CatalogTypeConfigurations());
        modelBuilder.ApplyConfiguration(new CatalogItemConfigurations());
    }
}