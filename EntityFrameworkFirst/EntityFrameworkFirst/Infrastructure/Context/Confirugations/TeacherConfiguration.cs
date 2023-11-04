using EntityFrameworkFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Infrastructure.Context.Confirugations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).IsRequired();
            builder.Property(x => x.Age).IsRequired();

            builder.HasOne(t => t.Subject)
                .WithMany(sub => sub.Teachers)
                .HasForeignKey(t => t.SubjectId);

            builder.HasOne(t => t.School)
            .WithMany(s => s.Teachers)
            .HasForeignKey(t => t.SchoolId);

            builder.HasMany(t => t.Students)
                .WithOne(st => st.Teacher)
                .HasForeignKey(st => st.TeacherId);

            builder.HasOne(t => t.Class)
                .WithOne(c => c.Teacher)
                .OnDelete(DeleteBehavior.Restrict);
            //.HasForeignKey

        }
    }
}
