using EntityFrameworkFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Context.Confirugations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.CaptionOfSchool).IsRequired();

            builder.HasMany(x => x.Classes)
                .WithOne(x => x.School)
                .HasForeignKey(x => x.Id);

            builder.HasMany(x => x.Teachers)
                .WithOne(x => x.School)
                .HasForeignKey(x => x.Id);

            builder.HasMany(x => x.Students)
                .WithOne(x => x.School)
                .HasForeignKey(x => x.Id);
        }
    }
}
