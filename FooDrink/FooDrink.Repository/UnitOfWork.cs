using FooDrink.Database;
using FooDrink.Database.Models;
using FooDrink.Repository.Interface;
using FooDrink.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace FooDrink.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextOptions<FooDrinkDbContext> _contextOptions;

        public UnitOfWork(DbContextOptions<FooDrinkDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            ProductRepository = new RepositoryGeneric<Product>(_contextOptions);
            UserRepository = new RepositoryGeneric<User>(_contextOptions);
            RestaurantRepository = new RepositoryGeneric<Restaurant>(_contextOptions);
            AuthenticationRepository = new AuthenticationRepository(_contextOptions);
        }

        public IRepository<Product> ProductRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<Restaurant> RestaurantRepository { get; }
        public AuthenticationRepository AuthenticationRepository { get; }

        public void SaveChangeData()
        {
            throw new NotImplementedException();
        }
    }
}
