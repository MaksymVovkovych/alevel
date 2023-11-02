using EntityFrameworkFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(x => x.Subjects).WithMany(x => x.Students);
            builder.HasOne(x => x.Class).WithMany(x => x.Students);
            builder.HasOne(x => x.Teacher).WithMany(x => x.Students);
        }
    }
}
