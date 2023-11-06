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
            builder.HasOne(x => x.Supplier).WithMany().HasForeignKey(x => x.SupplierId).HasPrincipalKey(x=>x.Id).OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
                new Contract("a",true, 1, 1, 1, 1, 1, new DateTime(2023, 05, 30), Core.Entities.Enum.BillingChargeType.None, Core.Entities.Enum.BillingType.None, Core.Entities.Enum.EnrollmentType.None, Core.Entities.Enum.PricingType.None,Core.Entities.Enum.Stage.Opportunity) { Id = 1 },
                new Contract("b", true, 2, 2, 2, 2, 2, new DateTime(2023, 05, 30), Core.Entities.Enum.BillingChargeType.None, Core.Entities.Enum.BillingType.None, Core.Entities.Enum.EnrollmentType.None, Core.Entities.Enum.PricingType.None, Core.Entities.Enum.Stage.Opportunity) { Id = 2 },
                new Contract("c", true,3, 3, 3, 3, 3, new DateTime(2023, 05, 30), Core.Entities.Enum.BillingChargeType.None, Core.Entities.Enum.BillingType.None, Core.Entities.Enum.EnrollmentType.None, Core.Entities.Enum.PricingType.None, Core.Entities.Enum.Stage.Opportunity) { Id = 3 },
                new Contract("d", true,4, 4, 4, 4, 4, new DateTime(2023, 05, 30), Core.Entities.Enum.BillingChargeType.None, Core.Entities.Enum.BillingType.None, Core.Entities.Enum.EnrollmentType.None, Core.Entities.Enum.PricingType.None, Core.Entities.Enum.Stage.Opportunity) { Id = 4 },
                new Contract("f", true,5, 5, 5, 5, 5, new DateTime(2023, 05, 30), Core.Entities.Enum.BillingChargeType.None, Core.Entities.Enum.BillingType.None, Core.Entities.Enum.EnrollmentType.None, Core.Entities.Enum.PricingType.None, Core.Entities.Enum.Stage.Opportunity) { Id = 5 }
                );
        }
    }
}
