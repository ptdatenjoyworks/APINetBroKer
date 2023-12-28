using Core.Models.Profiles;
using Core.Repositories.User;
using Core.Services.Users;
using Domain.Service.User;
using Infrastructure.Context;
using Infrastructure.Repositories.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NetBrokerOpenIddict.Extensions;
using System.Security.Claims;

namespace NetBrokerOpenIddict
{
    public class StartUp
    {
        private IConfiguration configuration { get; }

        public StartUp(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<DataContext>(options =>
            {
                // Configure Entity Framework Core to use Microsoft SQL Server.
                options.UseSqlite(configuration.GetConnectionString("WebApiDatabase"));

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need to replace the default OpenIddict entities.
                options.UseOpenIddict();
            });


            services.ConfigureIdentity();

            ////Config Repositories
            services.AddScoped<IUserRepository, UserRepository>();

            ////Config Services
            services.AddScoped<IUserService, UserService>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                      .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                      {
                          options.LoginPath = "/account/login";
                      });

            services.AddAuthentication(op =>
            {
                op.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddOpenIddict()

                // Register the OpenIddict core components.
                .AddCore(options =>
                {
                    // Configure OpenIddict to use the Entity Framework Core stores and models.
                    // Note: call ReplaceDefaultEntities() to replace the default entities.
                    options.UseEntityFrameworkCore()
                           .UseDbContext<DataContext>();
                })

                // Register the OpenIddict server components.
                .AddServer(options =>
                {
                    // Enable the token endpoint.

                    options.AllowAuthorizationCodeFlow().RequireProofKeyForCodeExchange();
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                           .SetTokenEndpointUris("/connect/token")
                            .SetIntrospectionEndpointUris("connect/introspect");


                    // Enable the client credentials flow.
                    options.AllowClientCredentialsFlow();

                    // Register the signing and encryption credentials.
                    options.AddDevelopmentEncryptionCertificate()
                           .AddDevelopmentSigningCertificate()
                           .DisableAccessTokenEncryption();

                    // Register scopes (permissions)
                    options.RegisterScopes("api");

                    // Register the ASP.NET Core host and configure the ASP.NET Core options.
                    options.UseAspNetCore()
                            .EnableTokenEndpointPassthrough()
                            .EnableAuthorizationEndpointPassthrough(); ;
                })

                // Register the OpenIddict validation components.
                .AddValidation(options =>
                {
                    // Import the configuration from the local OpenIddict server instance.
                    options.UseLocalServer();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                });

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            //services.ConfigureJWT(configuration);
            // Register the worker responsible of seeding the database with the sample clients.
            // Note: in a real world application, this step should be part of a setup script.
            services.AddHostedService<Worker>();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(options =>
            {
                options.MapControllers();
                options.MapDefaultControllerRoute();
            });
        }
    }
}
