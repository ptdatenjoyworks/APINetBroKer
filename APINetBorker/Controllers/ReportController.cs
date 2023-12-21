using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APINetBorker.Controllers
{
    [Route("api/report")]
    [AllowAnonymous]
    public class ReportController : ApiControllerBase
    {
        private IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]
        [Route("{year}")]
        public async Task<IActionResult> GetReportByYear(int year)
        {
            var reportResponse = await reportService.GetSummaryByYear(year);
            return CreateSuccessResult(reportResponse);
        }
    }
}
