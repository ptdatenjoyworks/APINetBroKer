using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Sales;
using Core.Entities.Enum;

namespace Infrastructure.Context.Configurations
{
    internal class CommisionConfiguration : IEntityTypeConfiguration<Commision>
    {
        public void Configure(EntityTypeBuilder<Commision> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.SalesProgram).WithMany().HasForeignKey(x => x.SalesProgramId);
            builder.HasOne(x => x.DateConfig).WithOne(x => x.Commision).HasForeignKey<DateConfig>(p => p.CommisionId);
            builder.HasDiscriminator()
               .HasValue<ContractUpfront>("ContractUpfront")
               .HasValue<PercentageContractResidual>("PercentageContractResidual")
               .HasValue<QuarterlyUpfront>("QuarterlyUpfront");
        }
    }
    internal class ContractUpfrontConfiguration : IEntityTypeConfiguration<ContractUpfront>
    {
        public void Configure(EntityTypeBuilder<ContractUpfront> builder)
        {
          
            builder.HasData(
                new ContractUpfront(1, "ContractUpfront", ProgramAdderType.Override, 0.007m, 0.5m) { Id = 1 }
                );
        }
    }
    internal class PercentageContractResidualConfiguration : IEntityTypeConfiguration<PercentageContractResidual>
    {
        public void Configure(EntityTypeBuilder<PercentageContractResidual> builder)
        {
          
            builder.HasData(
                new PercentageContractResidual(1, "PercentageContractResidual", ProgramAdderType.Override, 0.007m, 0.5m) { Id = 2 }
                );
        }
    }
    internal class QuarterlyUpfrontConfiguration : IEntityTypeConfiguration<QuarterlyUpfront>
    {
        public void Configure(EntityTypeBuilder<QuarterlyUpfront> builder)
        {
          
            builder.HasData(
                new QuarterlyUpfront(1, "QuarterlyUpfront", ProgramAdderType.Override, 0.007m, 0.5m) { Id = 3}
                );
        }
    }
}
