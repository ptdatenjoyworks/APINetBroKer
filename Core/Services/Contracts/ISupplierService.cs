using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response;

namespace Core.Services.Contracts
{
    public interface ISupplierService : IServiceBase<SupplierResponse,SupplierRequest>
    {
        //Task Create(SupplierRequest entity);
    }
}
