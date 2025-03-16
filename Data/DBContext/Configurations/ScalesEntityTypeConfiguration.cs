using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.DBContext.Configurations
{
    public class ScalesEntityTypeConfiguration : IEntityTypeConfiguration<Scale>
    {
        public void Configure(EntityTypeBuilder<Scale> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Location)
                .WithMany(x => x.Scales)
                .HasForeignKey(x => x.LocationId)
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
                .Property(x => x.ScaleMfg)
                .HasColumnName("ScaleMfg")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.ScaleModel)
                .HasColumnName("ScaleModel")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.ScaleSerialNo)
                .HasColumnName("ScaleSerialNo")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.ScaleProperties)
                .HasColumnName("ScaleProperties")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.DateInstalled)
                .HasColumnName("DateInstalled")
                .HasColumnType("datetime");

            builder
                .Property(x => x.Installer)
                .HasColumnName("Installer")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.DateCalibrated)
                .HasColumnName("DateCalibrated")
                .HasColumnType("datetime");

            builder
                .Property(x => x.CalibratedBy)
                .HasColumnName("CalibratedBy")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Notes)
                .HasColumnName("Notes")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .ToTable("Scales", "dbo");

            builder
                .ToTable(c => c.HasCheckConstraint("CK__Scales__Id__59FA5E80", "([id]>(0))"));
        }
    }
}
