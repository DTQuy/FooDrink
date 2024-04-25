using FooDrink.Database.Models;

namespace FooDrink.Repository.Interface
{
    public interface IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }
    }


}

