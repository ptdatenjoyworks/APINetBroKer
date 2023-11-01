using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.User;

namespace Infrastructure.Context.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Address).HasComment("Maximum length for the full name is 255 characters");
            builder.HasData(
                new ApplicationUser("DN",new DateTime(2023,10,26),"MrDat",true, new DateTime(2023, 10, 26)) { Id =1},
                new ApplicationUser("HCM",new DateTime(2023,10,26),"MrD",true, new DateTime(2023, 10, 26)) { Id = 2},
                new ApplicationUser("HN",new DateTime(2023,10,26),"MrB",true, new DateTime(2023, 10, 26)) { Id = 3 },
                new ApplicationUser("QN",new DateTime(2023,10,26),"MrC",true, new DateTime(2023, 10, 26)) { Id = 4 },
                new ApplicationUser("HT",new DateTime(2023,10,26),"MrD",true, new DateTime(2023, 10, 26)) { Id = 5 }
                );
        }
    }
}
