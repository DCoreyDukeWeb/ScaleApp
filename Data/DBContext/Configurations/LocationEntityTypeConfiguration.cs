using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.DBContext.Configurations
{
    public class LocationEntityTypeConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasKey(x => x.Id);

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
                .Property(x => x.Address1)
                .HasColumnName("Address1")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Address2)
                .HasColumnName("Address2")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.City)
                .HasColumnName("City")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Zip)
                .HasColumnName("Zip")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Country)
                .HasColumnName("Country")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.LatLong)
                .HasColumnName("LatLong")
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
                .ToTable("Locations", "dbo");
        }
    }
}
