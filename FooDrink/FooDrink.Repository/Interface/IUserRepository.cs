using FooDrink.DTO.Request.User;
using FooDrink.DTO.Response.User;

namespace FooDrink.Repository.Interface
{
    public interface IUserRepository
    {
        Task<UserGetListResponse> GetApplicationProductList(UserGetListRequest request);
    }
}
