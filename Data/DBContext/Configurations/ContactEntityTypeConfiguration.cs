using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.DBContext.Configurations
{
    public class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
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
                .Property(x => x.Phone1)
                .HasColumnName("Phone1")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Phone2)
                .HasColumnName("Phone2")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Fax)
                .HasColumnName("Fax")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Email1)
                .HasColumnName("Email1")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Email2)
                .HasColumnName("Email2")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.Url)
                .HasColumnName("Url")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.LocationId)
                .HasColumnName("LocationId")
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
                .Property(x => x.LastContacted)
                .HasColumnName("LastContacted")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder
                .Property(x => x.Notes)
                .HasColumnName("Notes")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .ToTable("Contacts", "dbo");
        }
    }
}
