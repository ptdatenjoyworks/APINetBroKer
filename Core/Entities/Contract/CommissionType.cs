using Core.Entities.Enum;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Contract
{
    public class CommissionType
    {
        [Column("Id")]
        public int Id { get; private set; }

        public int SalesProgramId { get; private set; }

        public CommissionConfigurationType CommissionConfigurationType { get; private set; }

        public ProgramAdderType AdderType { get; private set; }

        public decimal ProgramAdder { get; private set; }
        public decimal MarginPercent { get; private set; }
    }
}
