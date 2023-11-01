using Core.Models.Response.User;

namespace Core.Services
{
    public interface IUserService : IServiceBase<UserResponse>
    {
        Task<UserResponse?> GetByUserName(string? userName);
        Task<UserResponse?> GetById(int id);
    }
}
