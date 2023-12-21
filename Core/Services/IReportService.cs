using Core.Models.Response.Report;

namespace Core.Services
{
    public interface IReportService
    {
        Task<ReportResponse> GetSummaryByYear(int year);
    }
}
