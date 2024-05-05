using FooDrink.Database.Models;
using FooDrink.DTO.Request;
using FooDrink.DTO.Request.Product;
using FooDrink.DTO.Response.Product;
using FooDrink.Repository;
using FooDrink.Repository.Interface;
using System.Collections.Generic;

namespace FooDrink.BussinessService.Service
{
    public class ProductService : IProductRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public IRepository<Product> ProductRepository => throw new NotImplementedException();

        public IRepository<User> UserRepository => throw new NotImplementedException();

        public IRepository<User>? AuthenticationRepository => throw new NotImplementedException();

        AuthenticationRepository IUnitOfWork.AuthenticationRepository => throw new NotImplementedException();

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

    }
}
