using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    internal class SupplierDepositConfiguration : IEntityTypeConfiguration<SupplierDeposit>
    {
        public void Configure(EntityTypeBuilder<SupplierDeposit> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x=>x.Suppliers).WithMany().HasForeignKey(x => x.SupplierId);
        }
    }
}
