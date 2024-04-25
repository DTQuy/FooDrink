using FooDrink.DTO.Request;

namespace FooDrink.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Add(T entity);
        bool Edit(T entity);
        bool DeleteById(Guid id);
        IEnumerable<T> GetWithPaging(IPagingRequest pagingRequest);
    }
}
