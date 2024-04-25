﻿using FooDrink.Database.Models;
using FooDrink.DTO.Request.User;
using FooDrink.DTO.Response.User;

namespace FooDrink.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserGetListResponse> GetApplicationUserList(UserGetListRequest request);
    }
}
