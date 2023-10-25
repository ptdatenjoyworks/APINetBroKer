using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class SalesProgram
    {
        [Column("Id")]
        public int? Id { get; set; }

        public EnergyUnitType EnergyUnitType { get; set; }

        public string? Description { get; set; }

        public string? SalesProgramType { get; set; }
    }
}
