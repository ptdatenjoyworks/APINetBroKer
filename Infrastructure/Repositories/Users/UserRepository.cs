using Core.Entities.User;
using Core.Repositories.User;
using Infrastructure.Context;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository : RepositoryBase<ApplicationUser>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }


    }
}
