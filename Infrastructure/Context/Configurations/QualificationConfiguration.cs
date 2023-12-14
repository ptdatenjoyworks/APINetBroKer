using Core.Entities.Sales;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    public class QualificationConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.HasDiscriminator()
                .HasValue<QualificationDate>("QualificationDate")
                .HasValue<QualificationAnnualUsage>("QualificationAnnualUsage");
        }
    }
    public class QualificationDateConfiguration : IEntityTypeConfiguration<QualificationDate>
    {
        public void Configure(EntityTypeBuilder<QualificationDate> builder)
        {

            builder.HasData(
                new QualificationDate(new DateTime(2023, 05, 01), new DateTime(2199, 12, 31),1) { Id = 1 },
                new QualificationDate(new DateTime(2023, 03, 01), new DateTime(2023, 03, 20),2) { Id = 2 }
                );
        }
    }
    public class QualificationAnnualUsageConfiguration : IEntityTypeConfiguration<QualificationAnnualUsage>
    {
        public void Configure(EntityTypeBuilder<QualificationAnnualUsage> builder)
        {
            builder.HasData(
                new QualificationAnnualUsage(50000, 100000, 2) { Id = 3 }
                );
        }
    }
}
