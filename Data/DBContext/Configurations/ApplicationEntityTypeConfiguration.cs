using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.DBContext.Configurations
{
    public class ApplicationEntityTypeConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
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
                .Property(x => x.RelativeUri)
                .HasColumnName("RelativeURI")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.IndexUrl)
                .HasColumnName("IndexURL")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.DirectoryPath)
                .HasColumnName("DirectoryPath")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.RepositoryUrl)
                .HasColumnName("RepositoryUrl")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.ApplicationType)
                .HasColumnName("ApplicationType")
                .HasColumnType("varchar")
                .IsUnicode(false);

            builder
                .Property(x => x.CurrentVersion)
                .HasColumnName("CurrentVersion")
                .HasColumnType("varchar")
                .IsUnicode(false)
                .HasDefaultValueSql("('1.0.0.0')");

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
                .ToTable("Applications", "dbo");
        }
    }
}
