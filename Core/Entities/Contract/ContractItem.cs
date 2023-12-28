using Core.Entities.Abstract;
using Core.Entities.Enum;
using Core.Entities.Sales;
using Core.Extensions;
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
            Status = Status.Submitted;

        }
        public ContractItem(Contract contract, string? utilityAccountNumber, DateTime startDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType, int? annualUsage, decimal? rate, decimal? adder)
        {
            Contracts = contract;
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
        public ContractItem(ICollection<ContractItemForecast> contractItemForecasts, Contract contract, string? utilityAccountNumber, DateTime startDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType, int? annualUsage, decimal? rate, decimal? adder)
        {
            ContractItemForecasts = contractItemForecasts;
            Contracts = contract;
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
        public ContractItem(SalesProgram salesProgram,ICollection<ContractItemForecast> contractItemForecasts, Contract contract, string? utilityAccountNumber, DateTime startDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType, int? annualUsage, decimal? rate, decimal? adder)
        {
            SalesProgram = salesProgram;
            ContractItemForecasts = contractItemForecasts;
            Contracts = contract;
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
       

        public ContractItem()
        {

        }
        public ContractItem(int? annualUsage, decimal contractMargin)
        {
            AnnualUsage = annualUsage;
            ContractMargin = contractMargin;
        }
        public ContractItem(DateTime startDate,int? annualUsage, decimal contractMargin, Contract contract,Supplier supplier)
        {
            StartDate = startDate;
            AnnualUsage = annualUsage;
            ContractMargin = contractMargin;
            Contracts = contract;
            Contracts.Supplier = supplier;
        }

        public ContractItem(int id, int? contractsId, Contract contracts, string utilityAccountNumber, DateTime startDate, DateTime endDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType, int? annualUsage, decimal? rate, decimal? adder, Status status, ForecastState forecastState, decimal contractMargin, decimal percentageOfContractMargin)
        {
            Id = id;
            ContractsId = contractsId;
            Contracts = contracts;
            UtilityAccountNumber = utilityAccountNumber;
            StartDate = startDate;
            EndDate = endDate;
            TermMonth = termMonth;
            ProductType = productType;
            EnergyUnitType = energyUnitType;
            AnnualUsage = annualUsage;
            Rate = rate;
            Adder = adder;
            Status = status;
            ForecastState = forecastState;
            ContractMargin = contractMargin;
            PercentageOfContractMargin = percentageOfContractMargin;
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

        public int? SaleProgramId { get; private set; }
        public SalesProgram SalesProgram { get; private set; }

        public Status Status { get; private set; }
        public ForecastState ForecastState { get; set; }
        public decimal ContractMargin { get; private set; }
        public decimal PercentageOfContractMargin { get; private set; }
        public ICollection<ContractItemForecast> ContractItemForecasts { get; set; } = new List<ContractItemForecast>();

        public void Update(int? contractId, DateTime startDate, int termMonth, ProductType? productType, EnergyUnitType? energyUnitType)
        {
            ContractsId = contractId;
            StartDate = startDate;
            TermMonth = termMonth;
            ProductType = productType;
            EnergyUnitType = energyUnitType;
        }

        public bool Verifity(List<SalesProgram> salesPrograms)
        {
            if (Status == Status.None || Status == Status.Rejected)
            {
                ForecastState = ForecastState.InvalidSalesData;
                return false;
            }
            else if (Status == Status.Rejected)
            {
                ForecastState = ForecastState.RejectedDeal;
                return false;
            }
            else if (!ContractsId.HasValue)
            {
                ForecastState = ForecastState.InvalidSalesData;
                return false;
            }
            else if (!Contracts.SupplierId.HasValue || !salesPrograms.Any())
            {
                ForecastState = ForecastState.MissingSalesProgram;
                return false;
            }
            var validSalePrograms = salesPrograms.Where(x => x.Qualifications.Any(a => a.QualificationVerifity(this)));
            if (!validSalePrograms.Any())
            {
                ForecastState = ForecastState.MissingSalesProgram;
                return false;
            }
            else
            {
                SalesProgram = validSalePrograms.OrderByDescending(x => x.Qualifications.Count(x => x.QualificationVerifity(this)))
                    .ThenBy(x => x.Qualifications.OfType<QualificationDate>()
                    .Max(p => p.EffectiveDate)).FirstOrDefault();
            }

            if (SalesProgram.Commisions.Any(x => !x.Validate()))
            {
                ForecastState = ForecastState.InvalidSalesData;
            }
            else
            {
                ForecastState = ForecastState.Reforecast;
            }
            return false;
        }

        public bool Forecast(List<SalesProgram> salesPrograms)
        {
            if (ForecastState == ForecastState.Complete)
            {
                ContractItemForecasts.Clear();
            }
            if (ForecastState != ForecastState.Reforecast)
            {
                return false;
            }
            if (salesPrograms == null || SalesProgram.Commisions != null)
            {
                return false;
            }
            foreach (var item in SalesProgram.Commisions)
            {
                 var forcastitems    = item.GetListContractItemForecast(this);
                forcastitems.ForEach(p => ContractItemForecasts.Add(p));
            }
            return true;
        }
    }

}
