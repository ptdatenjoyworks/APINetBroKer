using Core.Entities.Contract;
using Core.Models.Requests.Contract;
using Core.Models.Response;

namespace Core.Services
{
    public interface ISupplierService : IServiceBase<SupplierResponse>
    {
        Task Create(SupplierRequest entity);
    }
}
