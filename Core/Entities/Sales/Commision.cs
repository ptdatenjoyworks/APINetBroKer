using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
