using FooDrink.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FooDrink.Database
{
    public class FooDrinkDbContext : DbContext
    {
        public DbSet<User>? Users { get; set; }

        public DbSet<Restaurant>? Restaurants { get; set; }

        public DbSet<Menu>? Menus { get; set; }

        public DbSet<Order>? Orders { get; set; }

        public DbSet<Product>? Products { get; set; }

        public DbSet<Review>? Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=dangthanhquy23_ASP;User Id=dangthanhquy23_ASP;Password=11223344a;User Instance=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
