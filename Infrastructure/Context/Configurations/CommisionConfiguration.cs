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


            builder.HasData(
                new Commision(1, "ContractUpfront", ProgramAdderType.Override, 0.007m, 0.5m) { Id = 1 },
                new Commision(1, "PercentageContractResidual", ProgramAdderType.Override, 0.007m, 0.5m) { Id = 2 },
                new Commision(2, "QuarterlyUpfront", ProgramAdderType.Override, 0.007m, 0) { Id = 3 }
                );
        }
    }
}
