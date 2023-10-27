using Core.Entities.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    internal class SalesProgramConfiguration : IEntityTypeConfiguration<SalesProgram>
    {
        public void Configure(EntityTypeBuilder<SalesProgram> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x=>x.Qualifications).WithOne(x=>x.SalesProgram).HasForeignKey(x=>x.SalesProgramId);
            builder.HasMany(x=>x.Commisions).WithOne(x=>x.SalesProgram).HasForeignKey(x=>x.SalesProgramId);
        }
    }
}
