using Catalog.Host.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfigurations;

public class CatalogItemConfigurations : IEntityTypeConfiguration<CatalogItem>
{
    public void Configure(EntityTypeBuilder<CatalogItem> builder)
    {
        builder.ToTable("CatalogItem");

        builder.HasKey(i => i.Id);

        builder.Property(i => i.Description)
            .IsRequired(false);
        
        builder.Property(i => i.Name)
            .IsRequired(true)
            .HasMaxLength(50);
            
        builder.Property(i => i.Price);

        builder.Property(i => i.PictureFileName)
            .IsRequired(false);
        
        builder.Property(i => i.AvailableStock)
            .IsRequired(true);

        builder.HasOne(i => i.CatalogBrand)
            .WithMany()
            .HasForeignKey(i => i.CatalogBrandId)
            .IsRequired(false);;
        
        builder.HasOne(i => i.CatalogType)
            .WithMany()
            .HasForeignKey(i => i.CatalogTypeId)
            .IsRequired(false);;
    }
}