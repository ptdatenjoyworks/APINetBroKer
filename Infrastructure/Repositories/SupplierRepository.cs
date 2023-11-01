using Core.Entities.Contract;
using Core.Repositories;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISuppilerRepository
    {
        public SupplierRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
