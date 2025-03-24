using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.DBContext.Configurations
{
    public class ScaleTicketEntityTypeConfiguration : IEntityTypeConfiguration<ScaleTicket>
    {
        public void Configure(EntityTypeBuilder<ScaleTicket> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Scale)
                .WithMany(x => x.Scales)
                .HasForeignKey(x => x.ScaleId)
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
                .Property(x => x.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.CustomerId)
                .HasColumnName("CustomerId")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.TruckId)
                .HasColumnName("TruckId")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.DriverId)
                .HasColumnName("DriverId")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.WeightTare)
                .HasColumnName("WeightTare")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.WeightNet)
                .HasColumnName("WeightNet")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.WeightGross)
                .HasColumnName("WeightGross")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.VehicleType)
                .HasColumnName("VehicleType")
                .HasPrecision(10, 0);

            builder
                .Property(x => x.Notes)
                .HasColumnName("Notes")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .ToTable("ScaleTickets", "dbo");
        }
    }
}
