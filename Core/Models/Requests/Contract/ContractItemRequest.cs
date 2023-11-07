using Core.Entities.Abstract;
using Core.Entities.Enum;

namespace Core.Models.Requests.Contract
{
    public class ContractItemRequest : BaseClass
    {
        public int Id { get; set; }
        public int? ContractsId { get; set; }
        public int? UtilityAccountNumber { get; set; }
        public DateTime StartDate { get; set; }
        public int TermMonth { get; set; }
        public ProductType? ProductType { get; set; }
        public EnergyUnitType? EnergyUnitType { get; set; }
        public int? AnnualUsage { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Adder { get; set; }
    }
}
