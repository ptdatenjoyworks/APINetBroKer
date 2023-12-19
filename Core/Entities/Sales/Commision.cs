using Core.Entities.Contract;
using Core.Entities.Enum;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.WebSockets;

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
        public Commision(int? salesProgramId, string? commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent, decimal discountPercentage)
        {
            SalesProgramId = salesProgramId;
            CommissionConfigurationTypeId = commissionConfigurationTypeId;
            ProgramAdderType = programAdderType;
            ProgramAdder = programAdder;
            MarginPercent = marginPercent;
            DiscountPercentage = discountPercentage;
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
        public decimal DiscountPercentage { get; set; }


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
                    i == 1 ? contractItem.ContractItemForecasts.LastOrDefault().ForecastDate.AddMonths(1) : listContractItemForecast.LastOrDefault().ForecastDate.AddMonths(1)));
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
                var focastDate = i == 1 ? DateConfig.GetDateConfig(contractItem) : listContractItemForecast[i - 2].ForecastDate.AddMonths(3);
                listContractItemForecast.Add(new ContractItemForecast(contractItem.Id, i == residualQuantity ? contractMargin - listContractItemForecast.Sum(x => x.Amount) : quarterMargin, focastDate));
            }
            return listContractItemForecast;
        }
    }

    public class AnnualUpfront : Commision
    {
        public AnnualUpfront(int? salesProgramId, string commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent, decimal discountPercentage) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent, discountPercentage)
        {
        }

        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var amountPerYear = Math.Round(contractItem.AnnualUsage.GetValueOrDefault() * ProgramAdder.GetValueOrDefault(), 2, MidpointRounding.AwayFromZero);
            if (contractItem.TermMonth < 12)
            {
                amountPerYear = Math.Round(amountPerYear / 12 * ProgramAdder.GetValueOrDefault() * contractItem.TermMonth, 2, MidpointRounding.AwayFromZero);
            }
            var itemForecastCount = contractItem.TermMonth / 12;
            var listForecast = new List<ContractItemForecast>();
            var firstDateForecast = DateConfig.GetDateConfig(contractItem);
            var contractMargin = Math.Round(contractItem.AnnualUsage.GetValueOrDefault() * ProgramAdder.GetValueOrDefault() / 12 * contractItem.TermMonth, 2, MidpointRounding.AwayFromZero);

            for (int i = 1; i <= itemForecastCount; i++)
            {
                var totalAmout = listForecast.Where(x => x.Amount > 0).Sum(x => x.Amount);
                decimal currentAmount = amountPerYear;
                if (i == itemForecastCount)
                {
                    currentAmount = contractMargin - totalAmout;
                }
                listForecast.Add(new ContractItemForecast(contractItem.Id, currentAmount, firstDateForecast));
                if (DiscountPercentage != 0)
                {
                    listForecast.Add(new ContractItemForecast(contractItem.Id, Math.Round(currentAmount * (-DiscountPercentage), 2, MidpointRounding.AwayFromZero), firstDateForecast));
                }
                firstDateForecast = firstDateForecast.AddYears(1);
            }
            return listForecast;
        }
    }
    public class Bridge : Commision
    {

        public Bridge(decimal fee, int? salesProgramId, string commissionConfigurationTypeId)
            : base(salesProgramId, commissionConfigurationTypeId, ProgramAdderType.None, 0, 0)
        {
            Fee = fee;
        }

        public decimal Fee { get; set; }
        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            return new List<ContractItemForecast>
            {
                new ContractItemForecast(contractItem.Id,Fee,DateConfig.GetDateConfig(contractItem))
            };
        }
    }
    public class FirstAnnualUpfront : Commision
    {
        public FirstAnnualUpfront(int? salesProgramId, string commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent, decimal discountPercentage) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent, discountPercentage)
        {
        }

        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var amountPerYear = Math.Round(contractItem.AnnualUsage.GetValueOrDefault() * ProgramAdder.GetValueOrDefault(), 2, MidpointRounding.AwayFromZero);
            if (contractItem.TermMonth < 12)
            {
                amountPerYear = Math.Round(amountPerYear / 12 * ProgramAdder.GetValueOrDefault() * contractItem.TermMonth, 2, MidpointRounding.AwayFromZero);
            }
            var listForecast = new List<ContractItemForecast>();
            var firstDateForecast = DateConfig.GetDateConfig(contractItem);
            listForecast.Add(new(contractItem.Id, amountPerYear, firstDateForecast));
            if (DiscountPercentage != 0)
            {
                listForecast.Add(new ContractItemForecast(contractItem.Id, Math.Round(amountPerYear * (-DiscountPercentage), 2, MidpointRounding.AwayFromZero), firstDateForecast));
            }
            return listForecast;
        }
    }
    public class FirstAnnualUpfront25kMax : Commision
    {
        public FirstAnnualUpfront25kMax(int? salesProgramId, string commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent)
        {
        }

        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var amountPerYear = Math.Round(contractItem.AnnualUsage.GetValueOrDefault() * ProgramAdder.GetValueOrDefault(), 2, MidpointRounding.AwayFromZero);
            if (contractItem.TermMonth < 12)
            {
                amountPerYear = Math.Round(amountPerYear / 12 * ProgramAdder.GetValueOrDefault() * contractItem.TermMonth, 2, MidpointRounding.AwayFromZero);
            }
            if (amountPerYear > 25000) amountPerYear = 25000;
            var listForecast = new List<ContractItemForecast>();
            var firstDateForecast = DateConfig.GetDateConfig(contractItem);
            listForecast.Add(new(contractItem.Id, amountPerYear, firstDateForecast));
            return listForecast;
        }
    }
    public class PercentageAdderResidual : Commision
    {
        public PercentageAdderResidual(int? salesProgramId, string commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent)
        {
        }

        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var contractMargin = Math.Round((contractItem.AnnualUsage.GetValueOrDefault() * ProgramAdder.GetValueOrDefault() / 12 * contractItem.TermMonth) * MarginPercent.GetValueOrDefault(), 2, MidpointRounding.AwayFromZero);
            var amountPerMonth = Math.Round(contractMargin / contractItem.TermMonth, 2, MidpointRounding.AwayFromZero);
            var firstDateForecast = DateConfig.GetDateConfig(contractItem);
            var listForecast = new List<ContractItemForecast>();

            for (int i = 1; i <= contractItem.TermMonth; i++)
            {
                var totalAmout = listForecast.Sum(x => x.Amount);
                decimal currentAmount = amountPerMonth;
                if (i == contractItem.TermMonth)
                {
                    currentAmount = contractMargin - totalAmout;
                }
                listForecast.Add(new ContractItemForecast(contractItem.Id, currentAmount, firstDateForecast));
                firstDateForecast = firstDateForecast.AddMonths(1);
            }
            return listForecast;
        }
    }

    public class PercentageFirstAnnualRemainderResidual : Commision
    {
        public PercentageFirstAnnualRemainderResidual(int? salesProgramId, string commissionConfigurationTypeId, ProgramAdderType programAdderType, decimal? programAdder, decimal? marginPercent) : base(salesProgramId, commissionConfigurationTypeId, programAdderType, programAdder, marginPercent)
        {
        }

        public override List<ContractItemForecast> GetListContractItemForecast(ContractItem contractItem)
        {
            var contractMargin = (contractItem.AnnualUsage.GetValueOrDefault() * ProgramAdder.GetValueOrDefault() / 12 * contractItem.TermMonth) * MarginPercent.GetValueOrDefault();
            var firstDateForecast = DateConfig.GetDateConfig(contractItem);
            var listForecast = new List<ContractItemForecast>();
            var amountForFirstYear = contractMargin / (contractItem.TermMonth / 12);
            var amountPerMonth = Math.Round(amountForFirstYear / 12, 2, MidpointRounding.AwayFromZero);
            if (contractItem.TermMonth < 12)
            {
                amountPerMonth = Math.Round(contractMargin / contractItem.TermMonth, 2, MidpointRounding.AwayFromZero);
            }
            var monthOfLoop = contractItem.TermMonth > 12 ? 12 : contractItem.TermMonth;
            for (int i = 1; i <= monthOfLoop; i++)
            {
                var totalAmout = listForecast.Sum(x => x.Amount);
                decimal currentAmount = amountPerMonth;
                if (i == monthOfLoop)
                {
                    currentAmount = (monthOfLoop * amountPerMonth) - totalAmout;
                }
                listForecast.Add(new ContractItemForecast(contractItem.Id, currentAmount, firstDateForecast));
                firstDateForecast = firstDateForecast.AddMonths(1);
            }
            return listForecast;
        }
    }
}
