using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Sales;

namespace Infrastructure.Context.Configurations
{
    internal class CommisionConfiguration : IEntityTypeConfiguration<Commision>
    {
        public void Configure(EntityTypeBuilder<Commision> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.SalesProgram).WithMany().HasForeignKey(x => x.SalesProgramId);
            builder.HasOne(x => x.DateConfig).WithMany().HasForeignKey(x => x.DateConfigId);
        }
    }
}
