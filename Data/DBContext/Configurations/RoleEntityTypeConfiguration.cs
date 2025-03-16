using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace Data.DBContext.Configurations
{
    public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
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
                .ToTable("Roles", "dbo");
        }
    }
}
