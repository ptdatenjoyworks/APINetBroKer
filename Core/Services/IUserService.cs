using Core.Entities.User;

namespace Core.Services
{
    public interface IUserService : IServiceBase<ApplicationUser>
    {
        Task<ApplicationUser?> GetByUserName(string? userName);
        Task<ApplicationUser?> GetById(int id);
    }
}
