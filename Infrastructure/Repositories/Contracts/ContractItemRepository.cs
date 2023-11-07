using Core.Entities.Contract;
using Core.Repositories.Contract;
using Infrastructure.Context;

namespace Infrastructure.Repositories.Contracts
{
    public class ContractItemRepository : RepositoryBase<ContractItem>, IContractItemRepository
    {
        public ContractItemRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
