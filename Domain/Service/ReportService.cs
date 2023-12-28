﻿using Core.Entities.Contract;
using Core.Entities.Enum;
using Core.Models.DTO;
using Core.Models.Response.Report;
using Core.Repositories.Contract;
using Core.Services;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Service
{
    public class ReportService : IReportService
    {
        private readonly IContractItemRepository contractItemRepository;

        public ReportService(IContractItemRepository contractItemRepository)
        {
            this.contractItemRepository = contractItemRepository;
        }
        public async Task<ReportResponse> GetSummaryByYear(int year)
        {
            try
            {
                //get date
                var startDate = new DateTime(year, 01, 01);
                var endDate = new DateTime(year, 12, 31, 23, 59, 59);
                var reportReponse = new ReportResponse();
                //get contractItems
                var items = await contractItemRepository.FindByConditionWithoutSaveAsync(x => (x.Status != Status.Rejected && x.Status != Status.Assumed)
                                            && x.StartDate >= startDate && x.StartDate <= endDate,
                                            t => new ContractItemDTO(t.StartDate, t.AnnualUsage, t.ContractMargin, t.Contracts.SupplierId, t.Contracts.Supplier.Name)
                                            );

                //calculator margin
                var totalAnnualMargin = items.Sum(x => (decimal)x.AnnualUsage);
                var averageAnnualMargin = (decimal)totalAnnualMargin / 12;
                var totalContractMargin = items.Sum(x => (decimal)x.ContractMargin);
                var averageContractMargin = (decimal)totalAnnualMargin / 12;

                var dateStartLastyear = startDate.AddYears(-1);
                var dateEndLastyear = endDate.AddYears(-1);
                var itemsOfLastYear = await contractItemRepository.FindByConditionWithoutSaveAsync(x => (x.Status != Status.Rejected && x.Status != Status.Assumed)
                                            && x.StartDate >= dateStartLastyear && x.StartDate <= dateEndLastyear, p => new ContractItemDTO(p.AnnualUsage, p.ContractMargin));

                var totalAnnualMarginOfLastYear = itemsOfLastYear.Sum(x => (decimal)x.AnnualUsage);
                var averageAnnualMarginOfLastYear = (decimal)totalAnnualMarginOfLastYear / 12;
                var totalContractMarginOfLastYear = itemsOfLastYear.Sum(x => (decimal)x.ContractMargin);
                var averageContractMarginOfLastYear = (decimal)totalContractMarginOfLastYear / 12;

                var precentOfTotalAnnualMargin = totalAnnualMarginOfLastYear != 0 ? ((totalAnnualMargin - totalAnnualMarginOfLastYear) / totalAnnualMarginOfLastYear) * 100 : 0;
                var precentOfAverageAnnualMargin = averageAnnualMarginOfLastYear != 0 ? ((averageAnnualMargin - averageAnnualMarginOfLastYear) / averageAnnualMarginOfLastYear) * 100 : 0;
                var precentOfTotalContractMargin = totalContractMarginOfLastYear != 0 ? ((totalContractMargin - totalContractMarginOfLastYear) / totalContractMarginOfLastYear) * 
                    
                    100 : 0;
                var precentOfAverageContractMargin = averageContractMarginOfLastYear != 0 ? ((averageContractMargin - averageContractMarginOfLastYear) / averageContractMarginOfLastYear) * 100 : 0;
                //set margin
                reportReponse.TotalAnnualMargin = new CardReportResponse(totalAnnualMargin, totalAnnualMarginOfLastYear, Math.Round(precentOfTotalAnnualMargin, 2, MidpointRounding.AwayFromZero));
                reportReponse.AverageAnnualMargin = new CardReportResponse(averageAnnualMargin, averageAnnualMarginOfLastYear, Math.Round(precentOfAverageAnnualMargin, 2, MidpointRounding.AwayFromZero));
                reportReponse.TotalContractMargin = new CardReportResponse(totalContractMargin, totalContractMarginOfLastYear, Math.Round(precentOfTotalContractMargin, 2, MidpointRounding.AwayFromZero));
                reportReponse.AverageContractMargin = new CardReportResponse(averageContractMargin, averageContractMarginOfLastYear, Math.Round(precentOfAverageContractMargin, 2, MidpointRounding.AwayFromZero));

                //get top 10 supplier
                var topSupplier = items.GroupBy(x => x.SupplierId).OrderByDescending(p => p.Sum(t => t.ContractMargin))
                    .Take(10)
                    .Select(p => new ChartReportResponse(p.FirstOrDefault().SupplierName, p.Sum(p => p.ContractMargin.GetValueOrDefault())))
                    .ToList();
                reportReponse.TopSupplier.AddRange(topSupplier); ;

                //get annual margin by month
                reportReponse.AnnualMarginSeries = new List<ChartReportResponse>();
                reportReponse.ContractMarginSeries = new List<ChartReportResponse>();
                for (int i = 1; i <= 12; i++)
                {
                    var totalAnnualMarginOfMonth = items.Where(x => x.StartDate.Month == i).Sum(p => (decimal)p.AnnualUsage);
                    var totalContractMarginOfMonth = items.Where(x => x.StartDate.Month == i).Sum(p => (decimal)p.ContractMargin);
                    reportReponse.AnnualMarginSeries.Add(new ChartReportResponse(i.ToString(), totalAnnualMarginOfMonth));
                    reportReponse.ContractMarginSeries.Add(new ChartReportResponse(i.ToString(), totalContractMarginOfMonth));
                }

                return reportReponse;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
 