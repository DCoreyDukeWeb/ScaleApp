using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.DBContext.Configurations
{
    public class RoleHasPermissionsEntityTypeConfiguration : IEntityTypeConfiguration<RoleHasPermissions>
    {
        public void Configure(EntityTypeBuilder<RoleHasPermissions> builder)
        {
      
         
            builder
                .Property(x => x.RoleId)
                .HasColumnName("RoleId")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.PermissionId)
                .HasColumnName("PermissionId")
                .HasPrecision(10, 0);

            builder
                .ToTable("RoleHasPermissions", "dbo");
        }
    }
}
