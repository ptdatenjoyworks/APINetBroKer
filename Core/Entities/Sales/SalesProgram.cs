using Core.Entities.Contract;
using Core.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class SalesProgram
    {
        public SalesProgram(EnergyUnitType energyUnitType, string? description, string? salesProgramType)
        {
            EnergyUnitType = energyUnitType;
            Description = description;
            SalesProgramType = salesProgramType;
        } 
        public SalesProgram(ICollection<Commision> commision,EnergyUnitType energyUnitType, string? description, string? salesProgramType)
        {
            Commisions = commision;
            EnergyUnitType = energyUnitType;
            Description = description;
            SalesProgramType = salesProgramType;
        }

        [Column("Id")]
        public int? Id { get; set; }

        public EnergyUnitType EnergyUnitType { get; private set; }

        public string? Description { get; private set; }

        public string? SalesProgramType { get; private set; }

        public ICollection<Qualification> Qualifications { get; private set; }

        public ICollection<Commision> Commisions { get; private set; }
    }
}
