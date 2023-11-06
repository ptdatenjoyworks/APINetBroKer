using Core.Services;
using Core.Services.Contracts;
using Core.Services.Users;
using Domain.Service.Contracts;
using Domain.Service.User;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Service
{
    public static class ServicesRegister
    {
        public static void UseServices(this IServiceCollection services) 
        { 
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<ILoggerManager, LoggerManager>();
            services.AddScoped<IContractService, ContractService>();
        }
    }
}
