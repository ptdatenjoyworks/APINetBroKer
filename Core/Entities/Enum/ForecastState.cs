namespace Core.Entities.Enum
{
    public enum ForecastState
    {
        Verification,
        MissingSalesProgram,
        InvalidSalesData,
        Reforecast,
        Complete, 
        Locked,
        FailedForecast,
        RejectedDeal,
        NonForecastable
    }
}
