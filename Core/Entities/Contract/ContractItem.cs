using Core.Entities.Abstract;
using Core.Entities.Enum;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class ContractItem : BaseClass
    {
        public ContractItem(int? contractsId, string? utilityAccountNumber, DateTime startDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType, int? annualUsage, decimal? rate, decimal? adder)
        {
            ContractsId = contractsId;
            UtilityAccountNumber = utilityAccountNumber;
            StartDate = startDate;
            EndDate = StartDate.AddMonths(termMonth);
            TermMonth = termMonth;
            ProductType = productType;
            EnergyUnitType = energyUnitType;
            AnnualUsage = annualUsage;
            Rate = rate;
            Adder = adder;
            var energyProductType = energyUnitType.GetTypeProduct();
            if (energyProductType != ProductType)
            {
                throw new ArgumentException($"ProductType : {ProductType}  khong phu hop voi Energy : {energyUnitType}");
            }

        }

        private ContractItem()
        {

        }

        [Column("Id")]
        public int Id { get; set; }
        //FK Contracts
        public int? ContractsId { get; private set; }
        public Contract? Contracts { get; private set; }

        public string? UtilityAccountNumber { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate
        {
            get; private set;
        }
        public int TermMonth { get; private set; }
        public ProductType? ProductType { get; private set; }
        public EnergyUnitType? EnergyUnitType { get; private set; }
        public int? AnnualUsage { get; private set; }
        public decimal? Rate { get; private set; }
        public decimal? Adder { get; private set; }
        public ICollection<ContractItemAttchment> Attachments { get; set; } = new HashSet<ContractItemAttchment>();

        public void Update(int? contractId, DateTime startDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType)
        {
            ContractsId = contractId;
            StartDate = startDate;
            TermMonth = termMonth;
            ProductType = productType;
            EnergyUnitType = energyUnitType;
        }

    }
}
