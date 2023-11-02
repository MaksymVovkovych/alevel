using EntityFrameworkFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasOne(x => x.Teacher).WithOne(x => x.ClassTeacher);
            builder.HasMany(x => x.Students).WithOne(x => x.Class);
        }
    }
}
