using Core.Entities.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Enum;

namespace Infrastructure.Context.Configurations
{
    public class DateConfigConfiguration : IEntityTypeConfiguration<DateConfig>
    {
        public void Configure(EntityTypeBuilder<DateConfig> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(
                new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2) { Id = 1 },
                new DateConfig(2, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.NoOffset, 0) { Id = 2 },
                new DateConfig(3, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.NoOffset, 0) { Id = 3 }
                );
        }
    }
}
