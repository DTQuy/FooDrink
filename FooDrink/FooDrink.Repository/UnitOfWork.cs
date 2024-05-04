using FooDrink.Database;
using FooDrink.Database.Models;
using FooDrink.Repository.Interface;
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
            AuthenticationRepository = new AuthenticationRepository(_contextOptions);
        }

        public IRepository<Product> ProductRepository { get; }
        public IRepository<User> UserRepository { get; }
        public AuthenticationRepository AuthenticationRepository { get; }
    }
}
