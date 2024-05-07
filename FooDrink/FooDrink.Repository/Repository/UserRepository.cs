using FooDrink.Database.Models;
using FooDrink.DTO.Request;
using FooDrink.DTO.Request.User;
using FooDrink.DTO.Response.User;
using FooDrink.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooDrink.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<User> AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserGetListResponse> GetApplicationUserListAsync(UserGetListRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetWithPaging(IPagingRequest pagingRequest)
        {
            throw new NotImplementedException();
        }
    }
}
