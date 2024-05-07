using FooDrink.Database.Models;
using FooDrink.DTO.Request.User;
using FooDrink.DTO.Response.User;
using FooDrink.Repository;
using FooDrink.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FooDrink.BussinessService.Service
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public IRepository<Product> ProductRepository => throw new NotImplementedException();

        public IRepository<User> UserRepository => throw new NotImplementedException();

        public AuthenticationRepository AuthenticationRepository => throw new NotImplementedException();

        public async Task<User> AddUser(User user)
        {
            // Add user to the repository
            return await _unitOfWork.UserRepository.AddAsync(user);
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            // Delete user from the repository
            return await _unitOfWork.UserRepository.DeleteByIdAsync(userId);
        }

        public async Task<bool> UpdateUser(User user)
        {
            // Update user in the repository
            return await _unitOfWork.UserRepository.EditAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers(UserGetListRequest request)
        {
            // Get all users from the repository
            return await _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            // Get user by ID from the repository
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public Task<UserGetListResponse> GetApplicationUserListAsync(UserGetListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
