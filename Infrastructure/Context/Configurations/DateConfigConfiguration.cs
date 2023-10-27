using Core.Entities.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    internal class DateConfigConfiguration : IEntityTypeConfiguration<DateConfig>
    {
        public void Configure(EntityTypeBuilder<DateConfig> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Commision).WithMany().HasForeignKey(x => x.CommisionId);
        }
    }
}
