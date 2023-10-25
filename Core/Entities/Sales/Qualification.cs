using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class Qualification
    {
        [Column("Id")]
        public int? Id { get; set; }

        //FK SalesProgram
        public int? SalesProgramId { get; set; }
        public SalesProgram? SalesProgram { get; set; }


        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? FromAnnualUsage { get; set; }
        public int? ToAnnualUsage { get; set; }
    }
}
