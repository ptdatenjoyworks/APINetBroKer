using Core.Entities.Contract;
using Core.Models.Response.Contracts;

namespace Core.Models.Response
{
    public class SupplierResponse
    {
        public string? Name { get; set; }

        public ICollection<ContractReponse> Contracts { get; set; }
        public ICollection<SupplierDeposit> SupplierDeposits { get; set; }
    }
}
