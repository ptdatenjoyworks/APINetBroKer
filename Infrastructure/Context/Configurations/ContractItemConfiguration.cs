using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Contract;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Context.Configurations
{
    internal class ContractItemConfiguration : IEntityTypeConfiguration<ContractItem>
    {
        public void Configure(EntityTypeBuilder<ContractItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Contracts).WithMany(x => x.ContractItems).HasForeignKey(x => x.ContractsId);

            builder.HasMany(x => x.Attachments).WithOne(x => x.ContractItem).HasForeignKey(x=>x.ContractItemId);

            builder.HasData(
                new ContractItem(1, 1, new DateTime(2023, 07, 01), 2, Core.Entities.Enum.ProductType.Elec, Core.Entities.Enum.EnergyUnitType.KWH, 1, 1, 1) { Id = 1 },
                new ContractItem(2, 2, new DateTime(2023, 07, 02), 3, Core.Entities.Enum.ProductType.Gas, Core.Entities.Enum.EnergyUnitType.THM, 2, 2, 2) { Id = 2 },
                new ContractItem(3, 3, new DateTime(2023, 07, 03), 4, Core.Entities.Enum.ProductType.Gas, Core.Entities.Enum.EnergyUnitType.MCF, 3, 3, 3) { Id = 3 },
                new ContractItem(4, 4, new DateTime(2023, 07, 04), 5, Core.Entities.Enum.ProductType.Elec, Core.Entities.Enum.EnergyUnitType.KWH, 4, 4, 4) { Id = 4 },
                new ContractItem(5, 5, new DateTime(2023, 07, 05), 6, Core.Entities.Enum.ProductType.Elec, Core.Entities.Enum.EnergyUnitType.KWH, 5, 5, 5) { Id = 5 }

                );
        }
    }
}
