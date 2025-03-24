using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScaleApp.Data.Entities;

namespace ScaleApp.Data.DBContext
{
    public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
#endif
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Application> Applications { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Location> Locations { get; set; } = null!;
        public DbSet<Permission> Permissions { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<RoleHasPermissions> RolePermissions { get; set; } = null!;
        public DbSet<Scale> Scales { get; set; } = null!;
        public DbSet<ScaleTicket> ScaleTickets { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
