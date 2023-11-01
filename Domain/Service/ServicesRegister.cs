using Core.Services;
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
        }
    }
}
