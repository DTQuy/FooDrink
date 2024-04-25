using FooDrink.Database.Models;
using FooDrink.Repository.Interface;

namespace FooDrink.Repository
{
    public class UnitOfWork
    {
        private readonly IRepository<Product> _productRepo;

        public UnitOfWork(IRepository<Product> productRepo)
        {
            _productRepo = productRepo ?? throw new ArgumentNullException(nameof(productRepo));
        }
    }

}
