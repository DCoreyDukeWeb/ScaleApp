using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.DBContext.Configurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
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
