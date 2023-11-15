using Core.Entities.Abstract;
using Core.Entities.Contract;
using Core.Entities.Enum;

namespace Core.Models.Response.Contracts
{
    public class ContractItemReponse : BaseClass
    {
        public string? UtilityAccountNumber { get; set; }
        public int TermMonth { get; set; }
        public ProductType? ProductType { get; set; }
        public EnergyUnitType? EnergyUnitType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate
        {
            get; set;
        }
        public ICollection<ContractItemAttchment> Attachments { get; set; }
    }
}
