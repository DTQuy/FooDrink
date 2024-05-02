using FooDrink.DTO.Request;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FooDrink.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        public Task<T?> GetByIdAsync(Guid id);
        public Task<IEnumerable<T>> GetAll();
        public Task<T> AddAsync(T entity);
        public Task<bool> EditAsync(T entity);
        public Task<bool> DeleteByIdAsync(Guid id);
        public IEnumerable<T> GetWithPaging(IPagingRequest pagingRequest);
    }
}
