using Core.Entities.Abstract;
using Core.Entities.Enum;
using Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class ContractItem : BaseClass
    {
        public ContractItem(int? contractsId, int? utilityAccountNumber, DateTime startDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType, int? annualUsage, decimal? rate, decimal? adder)
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
            var energyProductType =  energyUnitType.GetTypeProduct();
            if(energyProductType != ProductType)
            {
                throw new ArgumentException($"ProductType : {ProductType}  khong phu hop voi Energy : {energyUnitType}");
            }

        }
        private ContractItem()
        {

        }

        [Column("Id")]
        public int? Id { get; set; }
        //FK Contracts
        public int? ContractsId { get; set; }
        public Contract? Contracts { get; set; }

        public int? UtilityAccountNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate 
        {
          get; set;
        } 
        public int TermMonth { get; set; }
        public ProductType? ProductType { get; set; }
        public EnergyUnitType? EnergyUnitType { get; set; }
        public int? AnnualUsage { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Adder { get; set; }

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
