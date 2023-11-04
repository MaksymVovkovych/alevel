using EntityFrameworkFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SubjectName).IsRequired();

            builder.HasMany(sub => sub.Students)
                .WithMany(st => st.Subjects);

            builder.HasMany(sub => sub.Teachers)
                .WithOne(t => t.Subject)
                .HasForeignKey(t => t.SubjectId);

        }
    }
}
