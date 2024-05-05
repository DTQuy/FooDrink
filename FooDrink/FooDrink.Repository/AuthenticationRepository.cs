using FooDrink.Database;
using FooDrink.Database.Models;
using FooDrink.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooDrink.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly DbContextOptions<FooDrinkDbContext> _contextOptions;

        public IRepository<Product>? ProductRepository => throw new NotImplementedException();

        public IRepository<User>? UserRepository => throw new NotImplementedException();

        AuthenticationRepository IUnitOfWork.AuthenticationRepository => throw new NotImplementedException();

        public AuthenticationRepository(DbContextOptions<FooDrinkDbContext> contextOptions)
        {
            _contextOptions = contextOptions ?? throw new ArgumentNullException(nameof(contextOptions));
        }
        public async Task<User?> GetByUsernameAndPassword(string username, string password)
        {
            using var context = new FooDrinkDbContext(_contextOptions);
            var entity = await context.Set<User>().FirstOrDefaultAsync(a => a.Username == username && a.Password == password && a.Status == true);
            return entity;
        }

        public async Task<User?> GetByUsername(string username)
        {
            using var context = new FooDrinkDbContext(_contextOptions);
            var entity = await context.Set<User>().FirstOrDefaultAsync(a => a.Username == username);
            return entity;
        }

        public async Task<User> AddAsync(User entity)
        {
            using (var context = new FooDrinkDbContext(_contextOptions))
            {
                await context.Set<User>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
            return entity;
        }
    }
}
