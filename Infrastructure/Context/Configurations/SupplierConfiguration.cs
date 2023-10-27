using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x=>x.Contracts).WithOne(x => x.Supplier).HasForeignKey(x=>x.SuppliersId);
            builder.HasMany(x=>x.SupplierDeposits).WithOne(x => x.Suppliers).HasForeignKey(x=>x.SupplierId);
        }
    }
}
