using AutoMapper;
using Core.Entities.Enum;
using Core.Entities.User;
using Core.Models.Requests.User;
using Core.Models.Response.User;
using Core.Repositories.User;
using Core.Services.Users;
using Microsoft.AspNetCore.Identity;

namespace Domain.Service.User
{

    public sealed class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IMapper mapper;
        private UserManager<Core.Entities.User.ApplicationUser> userManager;

        public UserService(IUserRepository userRepository, IMapper mapper, UserManager<Core.Entities.User.ApplicationUser> userManager)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<UserResponse> Create(UserRegisterRequest userRegisterRequest)
        {
            var user = mapper.Map<UserRegisterRequest, ApplicationUser>(userRegisterRequest);
            var result = await userRepository.CreateAsync(user);
            await userRepository.SaveAsync();
            var users = mapper.Map<ApplicationUser, UserResponse>(user);
            return users;
        }

        public Task<UserResponse> Create(UserResponse entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(int id)
        {
            var user = (await userRepository.FindByConditionAsync(x => x.Id == id)).FirstOrDefault();
            if (user != null)
            {
                user.Delete();
                await userRepository.SaveAsync();
                return true;
            }
            return false;
        }

        public async Task<List<UserResponse>> GetAll()
        {
            var users = (await userRepository.FindByConditionAsync(x => x.IsActive)).OfType<Core.Entities.User.ApplicationUser>().ToList();
            var result = mapper.Map<List<ApplicationUser>, List<UserResponse>>(users);
            return result;
        }

        public async Task<UserResponse?> GetById(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                //user.Roles = await userManager.GetRolesAsync(user);
            }
            var result = mapper?.Map<ApplicationUser, UserResponse>(user);
            return result;
        }

        public async Task<UserResponse?> GetByUserName(string? userName)
        {
            var uesr = (await userRepository.FindByConditionAsync(x => x.UserName == userName)).FirstOrDefault();
            var result = mapper?.Map<ApplicationUser, UserResponse>(uesr);
            return result;
        }

        public async Task Update(UserRegisterRequest userRegisterRequest)
        {

            var user = await userRepository.FindById(userRegisterRequest.Id);
            if (user != null)
            {
                user.Update(userRegisterRequest.FullName, userRegisterRequest?.Email, userRegisterRequest.Address, userRegisterRequest.BirthDay, userRegisterRequest.PhoneNumber);
                await userRepository.SaveAsync();
            }
        }

        public Task Update(UserResponse entity)
        {
            throw new NotImplementedException();
        }
    }
}
