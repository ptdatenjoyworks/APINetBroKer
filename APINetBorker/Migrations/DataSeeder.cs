using Core.Entities.Enum;
using Core.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Core.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace APINetBorker.Migrations
{
    public static class DataSeeder
    {
        public static async Task SeedDefaultUserAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                await dbContext.Database.MigrateAsync(); // Ensure the database is created and up-to-date

                if (!dbContext.Users.Any())
                {
                    var admin = new ApplicationUser
                    {
                        UserName = "admin",
                        Email = "admin@example.com",
                        FullName = "Admin"
                    };

                    var result = await userManager.CreateAsync(admin, "admin123!");

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(admin, UserTypes.Admin.ToString());
                    }
                }
            }
        }
    }
}
