using FooDrink.Database.Models;

namespace FooDrink.Repository.Interface
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }
        public IRepository<User> UserRepository { get; }
        public AuthenticationRepository AuthenticationRepository { get; }
        public void SaveChangeData();
    }
}

