using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DBContext.Configurations
{
    public class UserHasRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserHasRole>
    {
        public void Configure(EntityTypeBuilder<UserHasRole> builder)
        {
            builder
                .Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .HasPrecision(10, 0);

            builder
                .ToTable("UserHasRoles", "dbo");
        }
    }
}
