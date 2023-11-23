using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Core.Services.Contracts
{
    public interface IContractItemService : IServiceBase<ContractItemReponse, ContractItemRequest>
    {
        Task<List<ContractItemReponse>> GetAll();
        Task<bool> Update(ContractItemRequest entity, bool isDelete);
        Task<bool> CreateContractItem(ContractItemCreateRequest contractItemRequest);

        Task<Dictionary<string, byte[]>> DownloadContractItemAttachment(int id);
        Task DownloadAllContractItemAttachments(int id, Stream stream);

    }
}
