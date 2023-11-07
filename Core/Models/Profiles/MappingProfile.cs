using AutoMapper;
using Core.Entities.Contract;
using Core.Entities.User;
using Core.Models.Requests.Contract;
using Core.Models.Requests.User;
using Core.Models.Response;
using Core.Models.Response.Contracts;
using Core.Models.Response.User;
using System.Security.Cryptography.X509Certificates;

namespace Core.Models.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserResponse>().ReverseMap();
            //CreateMap<UserResponse, ApplicationUser>();
            CreateMap<Supplier, SupplierResponse>().ReverseMap();
            CreateMap<Contract, ContractReponse>().ReverseMap();
            CreateMap<Contract, ContractReponse>()
                .ForMember(p=>p.CloserName, p=>p.MapFrom(f=>f.Closer.FullName))
                .ReverseMap();
            CreateMap<UserRegisterRequest, ApplicationUser>();
            CreateMap<SupplierRequest,Supplier>().ReverseMap();
            CreateMap<UserUpdateRequest, ApplicationUser>();

            CreateMap<ContractItem, ContractItemReponse>().ReverseMap();
            CreateMap<ContractItem, ContractItemRequest>().ReverseMap();


        }
    }
}
