namespace Core.Models.Response.Report
{
    public class ReportResponse
    {
        public ReportResponse() { }

        public ReportResponse(CardReportResponse totalAnnualMargin, CardReportResponse averageAnnualMargin, CardReportResponse totalContractMargin, CardReportResponse averageContractMargin, List<ChartReportResponse> topSupplier, List<ChartReportResponse> annualMarginSeries, List<ChartReportResponse> contractMarginSeries)
        {
            TotalAnnualMargin = totalAnnualMargin;
            AverageAnnualMargin = averageAnnualMargin;
            TotalContractMargin = totalContractMargin;
            AverageContractMargin = averageContractMargin;
            TopSupplier = topSupplier;
            AnnualMarginSeries = annualMarginSeries;
            ContractMarginSeries = contractMarginSeries;
        }

        public CardReportResponse TotalAnnualMargin { get; set; }
        public CardReportResponse AverageAnnualMargin { get; set; }
        public CardReportResponse TotalContractMargin { get; set; }
        public CardReportResponse AverageContractMargin { get; set; }

        public List<ChartReportResponse> TopSupplier { get; set; } = new List<ChartReportResponse>();
        public List<ChartReportResponse> AnnualMarginSeries { get; set; }
        public List<ChartReportResponse> ContractMarginSeries { get; set; }

    }

    public class CardReportResponse
    {
        public CardReportResponse() { }

        public CardReportResponse(decimal value, decimal prevValue, decimal percent)
        {
            Value = value;
            Percent = percent;
            PrevValue = prevValue;
        }

        public decimal Value { get; set; }
        public decimal PrevValue { get;set; }
        public decimal Percent { get; set; }
    }
    public class ChartReportResponse
    {
        public ChartReportResponse() { }

        public ChartReportResponse(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public decimal Value { get; set; }
    }



}
