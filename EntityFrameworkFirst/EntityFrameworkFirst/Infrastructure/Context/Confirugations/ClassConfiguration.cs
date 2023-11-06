using EntityFrameworkFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.ClassNumber).IsRequired();
            builder.Property(p => p.Capacity).IsRequired();

            builder.HasOne(c => c.Personal)
                .WithOne(p => p.Class)
                .HasForeignKey<Class>(c => c.PersonalId);

            builder.HasOne(c => c.School)
                .WithMany(sch => sch.Classes)
                .HasForeignKey(c => c.SchoolId);
        }
    }
}
