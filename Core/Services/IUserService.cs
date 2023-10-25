using Core.Entities.User;

namespace Core.Services
{
    public interface IUserService : IServiceBase<User>
    {
        Task<User?> GetByUserName(string? userName);
        Task<User?> GetById(int id);
    }
}
