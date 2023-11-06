using Core.Entities.Contract;
using Core.Repositories.Contract;
using Infrastructure.Context;

namespace Infrastructure.Repositories.Contracts
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
