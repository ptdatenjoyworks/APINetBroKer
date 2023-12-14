using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Contract;
using System.Security.Cryptography.X509Certificates;
using Core.Entities.Enum;

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
            builder.HasMany(x => x.ContractItemForecasts).WithOne(x => x.ContractItem).HasForeignKey(x=>x.ContractItemId);

            builder.HasData(
                new ContractItem(1, "9138014006", new DateTime(2023, 04, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m) { Id = 1} ,
                new ContractItem(1, "9138014006", new DateTime(2023, 03, 20), 16, ProductType.Gas, EnergyUnitType.CCF, 12303, 0.2275m, 0.073m) { Id = 2 },
                new ContractItem(1, "9138014006", new DateTime(2023, 04, 20), 12, ProductType.Elec, EnergyUnitType.MWH, 835, 23, 6.3m) { Id = 3 },
                new ContractItem(1, "9138014006", new DateTime(2023, 05, 13), 15, ProductType.Elec, EnergyUnitType.KWH, 160880, 0.02275m, 0.0073m) { Id = 4 },
                new ContractItem(1, "9138014006", new DateTime(2023, 06, 20), 12, ProductType.Gas, EnergyUnitType.THM, 89340, 0.3275m, 0.083m) { Id = 5 },
                new ContractItem(2, "177478640021", new DateTime(2023, 02, 20), 17, ProductType.Elec, EnergyUnitType.KWH, 36000, 0.0225m, 0.003m) { Id = 6 },
                new ContractItem(2, "177478640021", new DateTime(2023, 01, 28), 14, ProductType.Gas, EnergyUnitType.MCF, 4200, 2.275m, 0.073m) { Id = 7 },
                new ContractItem(2, "177478640021", new DateTime(2023, 04, 10), 16, ProductType.Elec, EnergyUnitType.MWH, 1500, 20.75m, 5.32m) { Id = 8 },
                new ContractItem(2, "177478640021", new DateTime(2023, 02, 23), 18, ProductType.Gas, EnergyUnitType.CCF, 60000, 0.1275m, 0.053m) { Id = 9 },
                new ContractItem(2, "177478640021", new DateTime(2023, 03, 05), 15, ProductType.Elec, EnergyUnitType.KWH, 15000, 0.04275m, 0.0033m) { Id = 10 }

                );
        }
    }
}
