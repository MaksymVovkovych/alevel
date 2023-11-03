using EntityFrameworkFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.ClassNumber).IsRequired();

            builder.HasOne(c => c.Teacher)
                .WithOne(t => t.Class)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Students)
                .WithOne(st => st.Class)
                .HasForeignKey(st => st.ClassId);

            builder.HasOne(c => c.School)
                .WithMany(sch => sch.Classes)
                .HasForeignKey(c => c.SchoolId);

        }
    }
}
