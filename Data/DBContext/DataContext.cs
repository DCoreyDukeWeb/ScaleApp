using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;

namespace Data.DBContext
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

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

        public DbSet<Application> Applications { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RoleHasPermissions> RoleHasPermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Scale> Scales { get; set; }
        public DbSet<ScaleTicket> ScaleTickets { get; set; }
        public DbSet<UserHasRole> UserHasRoles { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
