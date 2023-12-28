using Core.Entities.User;
using Core.Entities;
using Core.Settings;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace NetBrokerOpenIddict.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<ApplicationUser, ApplicationRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = true;
                o.Lockout.AllowedForNewUsers = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var appsettings = new AppSettings();
            configuration.Bind(appsettings.Section, appsettings);
            services.AddSingleton(appsettings);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = appsettings?.Auth?.ValidIssuer,
                    ValidAudience = appsettings?.Auth?.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appsettings?.Auth?.SecretKey ?? ""))
                };
            });
        }
    }
}
