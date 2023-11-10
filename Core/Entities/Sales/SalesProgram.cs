﻿using Core.Entities.Enum;
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

        [Column("Id")]
        public int? Id { get; set; }

        public EnergyUnitType EnergyUnitType { get; set; }

        public string? Description { get; set; }

        public string? SalesProgramType { get; set; }

        public ICollection<Qualification> Qualifications { get; set; }

        public ICollection<Commision> Commisions { get; set; }
    }
}
