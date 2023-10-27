using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Contract;

namespace Infrastructure.Context.Configurations
{
    internal class ContractItemConfiguration : IEntityTypeConfiguration<ContractItem>
    {
        public void Configure(EntityTypeBuilder<ContractItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Contracts).WithMany(x => x.ContractItems).HasForeignKey(x => x.ContractsId);
        }
    }
}
