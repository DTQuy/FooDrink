using FooDrink.Database.Models;
using FooDrink.DTO.Request;
using FooDrink.DTO.Request.Product;
using FooDrink.DTO.Response.Product;
using FooDrink.Repository;
using FooDrink.Repository.Interface;
using System.Collections.Generic;

namespace FooDrink.BussinessService.Service
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public IRepository<Product> ProductRepository => throw new NotImplementedException();

        public IRepository<User> UserRepository => throw new NotImplementedException();

        public IRepository<User>? AuthenticationRepository => throw new NotImplementedException();

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

        public IEnumerable<ProductGetListResponse> GetApplicationProductList(IPagingRequest pagingRequest)
        {
            var products = _unitOfWork.ProductRepository.GetWithPaging(pagingRequest);

            var productListResponse = products.Select(p => new ProductGetListResponse
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price.ToString(),
                CategoryList = p.CategoryList,
                MenuId = p.MenuId
            });

            return productListResponse;
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
