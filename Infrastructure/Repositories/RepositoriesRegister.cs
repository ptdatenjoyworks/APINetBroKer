using Core.Repositories.Contract;
using Core.Repositories.User;
using Infrastructure.Repositories.Contracts;
using Infrastructure.Repositories.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Repositories
{
    public static class RepositoriesRegister
    {
        public static void UseRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISuppilerRepository, SupplierRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IContractItemRepository, ContractItemRepository>();
        }
    }
}
