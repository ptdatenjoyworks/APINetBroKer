using Core.Models.Requests.User;
using Core.Models.Response.User;

namespace Core.Services.Users
{
    public interface IUserService : IServiceBase<UserResponse,UserRegisterRequest>
    {
        Task<UserResponse?> GetByUserName(string? userName);
        Task<UserResponse?> GetById(int id);
    }
}
