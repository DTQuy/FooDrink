using FooDrink.Database;
using FooDrink.DTO.Request;
using FooDrink.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FooDrink.Repository
{
    public class RepositoryGeneric<T> : IRepository<T> where T : class
    {
        private readonly DbContextOptions<FooDrinkDbContext> _contextOptions;

        public RepositoryGeneric(DbContextOptions<FooDrinkDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public T Add(T entity)
        {
            using FooDrinkDbContext context = new(_contextOptions);
            _ = context.Set<T>().Add(entity);
            _ = context.SaveChanges();
            return entity;
        }

        public bool DeleteById(Guid id)
        {
            using FooDrinkDbContext context = new(_contextOptions);
            T? entity = context.Set<T>().Find(id);
            if (entity != null)
            {
                _ = context.Set<T>().Remove(entity);
                _ = context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Edit(T entity)
        {
            using FooDrinkDbContext context = new(_contextOptions);
            context.Entry(entity).State = EntityState.Modified;
            _ = context.SaveChanges();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            using FooDrinkDbContext context = new(_contextOptions);
            return context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            try
            {
                using FooDrinkDbContext context = new(_contextOptions);
                T entity = context.Set<T>().Find(id)!;
                if (entity == null)
                {
                    Console.WriteLine($"Entity with ID {id} not found.");
                    return default!;
                }
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while getting entity with ID {id}: {ex.Message}");
                return default!;
            }
        }

        public IEnumerable<T> GetWithPaging(IPagingRequest pagingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
