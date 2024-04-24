using FooDrink.Database.Configuration;
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
            _ = optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER2017;Database=FooDrink;User Id=dangthanhquy_FooDrink;Password=Thanhquy12345@");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            _ = modelBuilder.ApplyConfiguration(new MenuConfig());
            _ = modelBuilder.ApplyConfiguration(new OrderConfig());
            _ = modelBuilder.ApplyConfiguration(new ProductConfig());
            _ = modelBuilder.ApplyConfiguration(new RestaurantConfig());
            _ = modelBuilder.ApplyConfiguration(new ReviewConfig());
            _ = modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
