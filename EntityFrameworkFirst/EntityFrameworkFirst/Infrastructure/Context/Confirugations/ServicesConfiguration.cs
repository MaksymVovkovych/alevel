using EntityFrameworkFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class ServicesConfiguration : IEntityTypeConfiguration<Services>
    {
        public void Configure(EntityTypeBuilder<Services> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.ServiceName).IsRequired();
            builder.Property(p => p.TypeService).IsRequired();
            builder.Property(p => p.Description).IsRequired();


            builder.HasMany(s => s.Personal)
                .WithMany(p => p.Services);


        }
    }
}
