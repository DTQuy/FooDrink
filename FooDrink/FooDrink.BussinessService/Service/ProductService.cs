using FooDrink.DTO.Request.Product;
using FooDrink.Repository.Interface;

namespace FooDrink.BussinessService.Service
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unit)
        {
            _unitOfWork = unit;
        }
        public IQueryable<ProductGetListRequest> GetListProduct(int id)
        {
            return (IQueryable<ProductGetListRequest>)_unitOfWork.ProductRepository.GetAll().AsQueryable();
        }
    }
}
