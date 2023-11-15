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
            //builder.HasOne(x=>x.Suppliers).WithMany().HasForeignKey(x => x.SupplierId);

            builder.HasData(
                new SupplierDeposit(1, new DateTime(2023, 05, 30), 1) { Id=1},
                new SupplierDeposit(2, new DateTime(2023, 05, 30), 2) { Id=2},
                new SupplierDeposit(3, new DateTime(2023, 05, 30), 3) { Id=3},
                new SupplierDeposit(4, new DateTime(2023, 05, 30), 4) { Id=4},
                new SupplierDeposit(5, new DateTime(2023, 05, 30), 5) { Id=5}
                ); 
        }
    }
}
