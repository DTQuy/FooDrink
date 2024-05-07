using FooDrink.Database.Models;
using FooDrink.DTO.Request;
using FooDrink.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooDrink.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        public Task<Product> AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetWithPaging(IPagingRequest pagingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
