using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;

namespace Core.Services.Contracts
{
    public interface IContractItemService : IServiceBase<ContractItemReponse,ContractItemRequest>
    {
        Task<List<ContractItemReponse>> GetAll();
        Task Update(ContractItemRequest entity);
    }
}
