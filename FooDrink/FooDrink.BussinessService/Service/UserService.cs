using FooDrink.Database;
using FooDrink.Database.Models;
using FooDrink.DTO.Request;
using FooDrink.DTO.Request.User;
using FooDrink.DTO.Response.User;
using FooDrink.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FooDrink.BussinessService.Service
{
    public class UserService : IUserRepository, IRepository<User>
    {
        public readonly DbContextOptions<FooDrinkDbContext> dbContextOptions;

        public UserService(DbContextOptions<FooDrinkDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public User Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserGetListResponse> GetApplicationUserList(UserGetListRequest request)
        {
            throw new NotImplementedException();
        }

        public User GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetWithPaging(IPagingRequest pagingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
