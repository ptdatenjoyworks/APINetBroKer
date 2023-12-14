using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class ContractItemForecast
    {
        public ContractItemForecast(int contractItemId, decimal amount, DateTime forecastDate)
        {
            ContractItemId = contractItemId;
            Amount = amount;
            ForecastDate = forecastDate;
        }

        [Column("Id")]
        public int Id { get; init; }
        public int ContractItemId { get; private set; }
        public ContractItem ContractItem { get; private set; }
        public decimal Amount { get;  set; }
        public DateTime ForecastDate { get; private set; }
        public int ForecastMonth { get; private set; }
        public int ForecastYear { get; private set; }
        public int ForecastMonthOfYear { get; private set; }
    }
}
