using Core.Entities.Contract;
using Core.Repositories.Contract;
using Infrastructure.Context;

namespace Infrastructure.Repositories.Contracts
{
    public class SupplierRepository : RepositoryBase<Supplier>, ISuppilerRepository
    {
        public SupplierRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
