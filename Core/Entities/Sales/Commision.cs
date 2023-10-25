using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class Commision
    {
        [Column("Id")]
        public int? Id { get; set; }

        //FK SalesProgram
        public int? SalesProgramId { get; set; }
        public SalesProgram? SalesProgram { get; set; }

        //FK DateConfig
        public int? DateConfigId { get; set; }
        public string? CommissionConfigurationTypeId { get; set; }
        public ProgramAdderType ProgramAdderType { get; set; }
        public decimal? ProgramAdder { get; set; }
        public decimal? MarginPercent { get; set; }
    }
}
