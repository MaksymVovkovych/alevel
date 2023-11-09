using EntityFrameworkFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkFirst.Confirugations
{
    public class StaffMemberConfiguration : IEntityTypeConfiguration<StaffMember>
    {
        public void Configure(EntityTypeBuilder<StaffMember> builder)
        {
            builder.HasKey(st => st.Id);
            builder.Property(st => st.Name).IsRequired();
            builder.Property(st => st.Surname).IsRequired();
            builder.Property(st => st.Email).IsRequired();

            builder.HasOne(p => p.Class)
                .WithOne(p => p.Personal)
                .HasForeignKey<Class>(c => c.PersonalId);

            builder.HasMany(p => p.Services)
                .WithMany(s => s.Personal);
        }
    }
}
