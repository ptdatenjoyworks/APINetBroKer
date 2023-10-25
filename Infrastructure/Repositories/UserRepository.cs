using Core.Entities.User;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }


    }
}
