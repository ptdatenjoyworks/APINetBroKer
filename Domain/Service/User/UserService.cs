using Core.Repositories;
using Core.Services;
using Microsoft.AspNetCore.Identity;

namespace Domain.Service.User
{

    public sealed class UserService : IUserService
    {
        private IUserRepository userRepository;
        private UserManager<Core.Entities.User.User> userManager;

        public UserService(IUserRepository userRepository,  UserManager<Core.Entities.User.User> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public async Task<Core.Entities.User.User> Create(Core.Entities.User.User user)
        {
            var result = await userRepository.CreateAsync(user);
            await userRepository.SaveAsync();
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var user = (await userRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (user != null)
            {
                user.IsActive = false;
                await Update(user);
                return true;
            }
            return false;
        }

        public async Task<List<Core.Entities.User.User>> GetAll()
        {
            var users = (await userRepository.FindByConditionAsync(x => x.IsActive)).OfType<Core.Entities.User.User>().ToList();
            return users;
        }

        public async Task<Core.Entities.User.User?> GetById(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                user.Roles = await userManager.GetRolesAsync(user);
            }
            return user;
        }

        public async Task<Core.Entities.User.User?> GetByUserName(string? userName)
        {
            return (await userRepository.FindByConditionAsync(x => x.UserName == userName)).FirstOrDefault();
        }

        public async Task Update(Core.Entities.User.User user)
        {
            await userRepository.UpdateAsync(user);
            await userRepository.SaveAsync();
        }
    }
}
