using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;

namespace Core.Services.Contracts
{
    public interface IContractService : IServiceBase<ContractReponse,ContractRequest>
    {
        //Task<bool> Create(ContractRequest contractRequest);
        Task Update(ContractRequest entity);
        //Task<(bool, string)> VerifityContract(int id);
    }
}
