using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;

namespace Core.Services.Contracts
{
    public interface IContractItemService : IServiceBase<ContractItemReponse, ContractItemRequest>
    {
        Task<List<ContractItemReponse>> GetAll();
        Task<bool> Update(ContractItemRequest entity, bool isDelete);
        Task<bool> CreateContractItem(ContractItemCreateRequest contractItemRequest);

        Task<(string filename, byte[] filebyte)> DownloadContractItemAttachment(int id);
        Task DownloadAllContractItemAttachments(int id, Stream stream);
        Task<(bool, string)> VerifityContract(int contractId);
        Task<(bool, string)> ForecastContractItem(int contractId);

    }
}
