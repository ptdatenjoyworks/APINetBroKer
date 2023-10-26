using Core.Entities.User;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }


    }
}
