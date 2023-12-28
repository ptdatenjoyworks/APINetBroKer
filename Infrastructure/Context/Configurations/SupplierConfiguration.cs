using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x=>x.Contracts).WithOne(x => x.Supplier).HasForeignKey(x=>x.SupplierId).HasPrincipalKey(x=>x.Id);
            builder.HasMany(x=>x.SupplierDeposits).WithOne(x => x.Suppliers).HasForeignKey(x=>x.SupplierId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Supplier("a") { Id = 1},
                new Supplier("b") { Id = 2},
                new Supplier("c") { Id = 3},
                new Supplier("d") { Id = 4},
                new Supplier("e") { Id = 5}
                );
        }
    }
}
