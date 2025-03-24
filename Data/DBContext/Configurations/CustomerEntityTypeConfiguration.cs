using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.DBContext.Configurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.Customers)
                .HasForeignKey(x => x.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(x => x.Contact)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => x.ContactId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.Name)
                .HasColumnName("Name")
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
                .Property(x => x.Notes)
                .HasColumnName("Notes")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .ToTable("Customers", "dbo");
        }
    }
}
