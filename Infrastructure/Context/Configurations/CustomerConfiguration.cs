using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context.Configurations
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x=>x.Contracts).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

            builder.HasData(
                new Customer("aaa") { Id = 1 },
                new Customer("bbb") { Id = 2 },
                new Customer("ccc") { Id = 3 },
                new Customer("ddd") { Id = 4 },
                new Customer("fff") { Id = 5 }
                );
        }
    }
}
