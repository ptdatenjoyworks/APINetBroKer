using Core.Entities.Abstract;
using Core.Entities.Enum;

namespace Core.Models.Requests.Contract
{
    public class ContractRequest : BaseClass
    {
        public int Id { get; set; } 
        public string? LegalEntityName { get; set; }
        public int SupplierId { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }
        public Stage Stage { get; set; }
    }
}
