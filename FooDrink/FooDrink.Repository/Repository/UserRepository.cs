using FooDrink.Database;
using FooDrink.DTO.Request.User;
using FooDrink.DTO.Response.User;
using FooDrink.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FooDrink.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly DbContextOptions<FooDrinkDbContext> dbContextOptions;

        public UserRepository(DbContextOptions<FooDrinkDbContext> dbContextOptions)
        {
            this.dbContextOptions = dbContextOptions;
        }

        public Task<UserGetListResponse> GetApplicationProductList(UserGetListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
