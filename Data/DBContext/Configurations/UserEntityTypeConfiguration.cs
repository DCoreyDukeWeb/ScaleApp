using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.DBContext.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Application)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.Username)
                .HasColumnName("Username")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Password)
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .IsUnicode(false);

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
                .ToTable("Users", "dbo");
        }
    }
}
