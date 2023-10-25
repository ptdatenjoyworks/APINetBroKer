using AutoMapper;
using Core.Entities.User;
using Core.Models.Requests.User;
using Core.Models.Response.User;

namespace Core.Models.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserResponse, User>();
            CreateMap<UserRegisterRequest, User>();
            CreateMap<UserUpdateRequest, User>();
        }
    }
}
