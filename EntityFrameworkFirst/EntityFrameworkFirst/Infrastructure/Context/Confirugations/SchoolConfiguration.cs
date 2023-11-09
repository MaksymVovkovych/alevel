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
            builder.Property(p => p.Address).IsRequired();
            builder.Property(p => p.CaptionOfSchool).IsRequired();

            builder.HasMany(sch => sch.Classes)
                .WithOne(c => c.School)
                .HasForeignKey(c => c.SchoolId);

        }
    }
}
