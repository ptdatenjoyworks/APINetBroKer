using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;

namespace Core.Services.Contracts
{
    public interface IContractItemService : IServiceBase<ContractItemReponse>
    {
        Task<List<ContractItemReponse>> GetAll();
        Task<bool> Create (ContractItemRequest contractItemRequest);
        Task Update(ContractItemRequest entity);
    }
}
