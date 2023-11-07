using Core.Entities.Abstract;
using Core.Entities.Enum;

namespace Core.Models.Response.Contracts
{
    public class ContractItemReponse : BaseClass
    {
        public int? UtilityAccountNumber { get; set; }
        public int TermMonth { get; set; }
        public ProductType? ProductType { get; set; }
        public EnergyUnitType? EnergyUnitType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate
        {
            get; set;
        }
    }
}
