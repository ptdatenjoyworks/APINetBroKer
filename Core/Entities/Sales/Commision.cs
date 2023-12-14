using Core.Entities.Contract;
using Core.Entities.Enum;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class Commision
    {
        public Commision(int? salesProgramId, string? commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent)
        {
            SalesProgramId = salesProgramId;
            CommissionConfigurationTypeId = commissionConfigurationTypeId;
            ProgramAdderType = programAdderType;
            ProgramAdder = programAdder;
            MarginPercent = marginPercent;
        }

        [Column("Id")]
        public int? Id { get; set; }

        //FK SalesProgram
        public int? SalesProgramId { get; private set; }
        public SalesProgram? SalesProgram { get; private set; }

        //FK DateConfig
        public DateConfig? DateConfig { get; private set; } = null;

        public string? CommissionConfigurationTypeId { get; private set; }
        public ProgramAdderType ProgramAdderType { get; private set; }
        public decimal? ProgramAdder { get; private set; }
        public decimal? MarginPercent { get; private set; }

        public virtual bool Validate()
        {
            return true;
        }
        public virtual List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            return null;
        }
        public void SetDateConfig(DateConfig dateConfig)
        {
            DateConfig = dateConfig;
        }
    }

    public class ContractUpfront : Commision
    {
        public ContractUpfront(int? salesProgramId, string? commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent)
        {
        }

        public override bool Validate()
        {
            if (ProgramAdder != null && MarginPercent != null && DateConfig != null)
            {
                return true;
            }
            return false;
        }
        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var contractMargin = Math.Round((decimal)(contractItem.AnnualUsage * contractItem.Adder / 12 * contractItem.TermMonth), 2);
            var percentageOfContractMargin = Math.Round((decimal)(contractMargin * MarginPercent), 2, MidpointRounding.AwayFromZero);
            DateTime forecastDate = DateConfig.GetDateConfig(contractItem);
            return new List<ContractItemForecast>
            {
                new ContractItemForecast(contractItem.Id,percentageOfContractMargin,forecastDate)
            };
        }
    }
    public class PercentageContractResidual : Commision
    {
        public PercentageContractResidual(int? salesProgramId, string? commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent)
        {
        }
        public override bool Validate()
        {
            if (ProgramAdder != null && MarginPercent != null && DateConfig != null)
            {
                return true;
            }
            return false;
        }
        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var contractMargin = Math.Round((decimal)(contractItem.AnnualUsage * contractItem.Adder / 12 * contractItem.TermMonth), 2);
            var percentageOfContractMargin = Math.Round((decimal)(contractMargin * MarginPercent), 2);
            var residualQuantity = contractItem.TermMonth - contractItem.ContractItemForecasts.Count();
            var residualAmount = Math.Round(contractMargin / contractItem.TermMonth, 0);
            var listContractItemForecast = new List<ContractItemForecast>();
            for (int i = 1; i <= residualQuantity; i++)
            {
                listContractItemForecast.Add(new ContractItemForecast(contractItem.Id, 
                    i == residualQuantity ? percentageOfContractMargin - listContractItemForecast.Sum(x => x.Amount) : residualAmount,
                    i == 1 ?  contractItem.ContractItemForecasts.LastOrDefault().ForecastDate.AddMonths(1) : listContractItemForecast.LastOrDefault().ForecastDate.AddMonths(1)));
            }
            return listContractItemForecast;
        }
    }

    public class QuarterlyUpfront : Commision
    {
        public QuarterlyUpfront(int? salesProgramId, string? commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent)
        {
        }
        public override bool Validate()
        {
            if (ProgramAdder != null && DateConfig != null)
            {
                return true;
            }
            return false;
        }
        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var contractMargin = Math.Round((decimal)(contractItem.AnnualUsage * contractItem.Adder / 12 * contractItem.TermMonth), 2);
            var quarterMargin = Math.Round((decimal)(contractItem.AnnualUsage * contractItem.Adder / 4), 2);
            var residualQuantity = Math.Round((decimal)(contractItem.TermMonth / 3), 0);
            var listContractItemForecast = new List<ContractItemForecast>();
            for (int i = 1; i <= residualQuantity; i++)
            {
                var focastDate = i == 1 ? DateConfig.GetDateConfig(contractItem) : listContractItemForecast[i-2].ForecastDate.AddMonths(3);
                listContractItemForecast.Add(new ContractItemForecast(contractItem.Id, i == residualQuantity ? contractMargin - listContractItemForecast.Sum(x => x.Amount) : quarterMargin, focastDate));
            }
            return listContractItemForecast;
        }
    }
}
