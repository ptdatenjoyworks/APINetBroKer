using Core.Entities.Abstract;

namespace Core.Models.Requests.Contract
{
    public class ContractRequest : BaseClass
    {
        public int Id { get; set; } 
        public string? LegalEntityName { get; set; }
        public int SupplierId { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }
    }
}
