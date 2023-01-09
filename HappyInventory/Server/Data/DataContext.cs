
using HappyInventory.Shared;
using Microsoft.EntityFrameworkCore;

namespace HappyInventory.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country { Id = 1,Name = "Egypt"}, new Country { Id = 2, Name = "Suadi Arabia" }, new Country { Id = 3, Name = "Qatar" });
            modelBuilder.Entity<Role>().HasData(new Role {Id=1,Name="Admin" }, new Role { Id = 2, Name = "Management" }, new Role { Id = 3, Name = "Auditor" });
        }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Item> Items { get; set; }  
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
