using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.DBContext.Configurations
{
    public class RoleHasPermissionsEntityTypeConfiguration : IEntityTypeConfiguration<RoleHasPermissions>
    {
        public void Configure(EntityTypeBuilder<RoleHasPermissions> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.RoleHasPermissions)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Permission)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder
                .Property(x => x.UpdatedOn)
                .HasColumnName("UpdatedOn")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder
                .ToTable("RoleHasPermissions", "dbo");
        }
    }
}
