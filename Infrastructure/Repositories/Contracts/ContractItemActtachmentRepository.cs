using Core.Entities.Contract;
using Core.Repositories.Contract;
using Infrastructure.Context;

namespace Infrastructure.Repositories.Contracts
{
    public class ContractItemActtachmentRepository : RepositoryBase<ContractItemAttchment>, IContractItemActtachmentRepository
    {
        public ContractItemActtachmentRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
