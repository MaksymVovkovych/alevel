using EntityFrameworkFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(st => st.Id);
            builder.Property(st => st.Name).IsRequired();
            builder.Property(st => st.Surname).IsRequired();
            builder.Property(st => st.Email).IsRequired();

            builder.HasOne(st => st.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(st => st.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(st => st.Teacher)
                .WithMany(t => t.Students)
                .HasForeignKey(st => st.TeacherId);

            builder.HasOne(st => st.School)
                .WithMany(s => s.Students)
                .HasForeignKey(st => st.SchoolId);

            builder.HasMany(sub => sub.Subjects)
                .WithMany(st => st.Students);
        }
    }
}
