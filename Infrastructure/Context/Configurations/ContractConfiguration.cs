using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configurations
{
    internal class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Closer).WithMany().HasForeignKey(x => x.CloserId);
            builder.HasOne(x => x.Fronter).WithMany().HasForeignKey(x => x.FronterId);
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
                new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity) { Id = 1 },
                new Contract("Jelly B", 1, 1, 2, 2, 2, new DateTime(2023, 05, 30), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity) { Id = 2 }
                );
        }
    }
}
