using Core.Entities.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Contracts).WithOne(x => x.Contact).HasForeignKey(x => x.ContactId);


            builder.HasData(
                new Contact("aaaa") { Id = 1},
                new Contact("bbbb") { Id = 2},
                new Contact("cccc") { Id = 3},
                new Contact("dddd") { Id = 4},
                new Contact("ffff") { Id = 5}
                );
        }
    }
}
