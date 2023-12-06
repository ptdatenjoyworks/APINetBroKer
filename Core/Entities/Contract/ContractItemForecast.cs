using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class ContractItemForecast
    {
        [Column("Id")]
        public int Id { get; init; }
        public int ContractItemId { get; private set; }
        public decimal Amount { get; private set; }
        public int ForecastDate { get; private set; }
        public int ForecastMonth { get; private set; }
        public int ForecastYear { get; private set; }
        public int ForecastMonthOfYear { get; private set; }
    }
}
