using Core.Entities.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    internal class SalesProgramConfiguration : IEntityTypeConfiguration<SalesProgram>
    {
        public void Configure(EntityTypeBuilder<SalesProgram> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x=>x.Qualifications).WithOne(x=>x.SalesProgram).HasForeignKey(x=>x.SalesProgramId);
            builder.HasMany(x=>x.Commisions).WithOne(x=>x.SalesProgram).HasForeignKey(x=>x.SalesProgramId);

            builder.HasData
                (
                new SalesProgram(Core.Entities.Enum.EnergyUnitType.THM, "description1", "type1") { Id = 1},
                new SalesProgram(Core.Entities.Enum.EnergyUnitType.MCF, "description2", "type2") { Id = 2},
                new SalesProgram(Core.Entities.Enum.EnergyUnitType.CCF, "description3", "type3") { Id = 3},
                new SalesProgram(Core.Entities.Enum.EnergyUnitType.KWH, "description4", "type4") { Id = 4},
                new SalesProgram(Core.Entities.Enum.EnergyUnitType.MWH, "description5", "type5") { Id = 5}
                );
        }
    }
}
