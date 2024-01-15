using Catalog.Host.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class CarConfigurations : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Year );
        builder.Property(c => c.Color);
        
        builder.HasOne(c => c.Brand)
            .WithMany()
            .HasForeignKey(c => c.BrandId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}