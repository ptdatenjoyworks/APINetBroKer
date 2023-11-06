using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;

namespace Core.Services.Contracts
{
    public interface IContractService : IServiceBase<ContractReponse>
    {
        Task<bool> Create(ContractRequest contractRequest);
        Task Update(ContractRequest entity);
    }
}
