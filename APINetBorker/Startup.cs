using APINetBorker.Controllers;
using APINetBorker.Extensions;
using Core.Models.Profiles;
using Core.Settings;
using Domain.Service;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using NLog;
using OpenIddict.Validation.AspNetCore;
using System.Security.Claims;

namespace APINetBorker
{
    public class Startup
    {
        private IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.AddDbContext<DataContext>(opts => opts.UseSqlite(configuration.GetConnectionString("WebApiDatabase")));


            //Config Repositories
            services.UseRepositories();

            //Config Services
            services.UseServices();

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters().AddApplicationPart(typeof(ApiControllerBase).Assembly);

            services.AddControllers().AddApplicationPart(typeof(ApiControllerBase).Assembly);

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.ConfigureIdentity();

            services.ConfigureJWT(configuration);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
            });


            // Register the OpenIddict validation components.
            services.AddOpenIddict()
                .AddValidation(options =>
                {
                    var a = configuration.GetSection("Keycloak")["SetIssuer"];
                    var b = configuration.GetSection("Keycloak")["ClientId"];
                    var c = configuration.GetSection("Keycloak")["ClientSecret"];
                    // Note: the validation handler uses OpenID Connect discovery
                    // to retrieve the address of the introspection endpoint.
                    options.SetIssuer(a);

                    // Configure the validation handler to use introspection and register the client
                    // credentials used when communicating with the remote introspection endpoint.
                    options.UseIntrospection().SetClientId(b)
                            .SetClientSecret(c);

                    // Register the System.Net.Http integration.
                    options.UseSystemNetHttp();

                    // Register the ASP.NET Core host.
                    options.UseAspNetCore();
                })
                ;

            services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
            services.AddAuthorization();
            //await services.InitData();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/500");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRewriter(new RewriteOptions().Add(new RedirectLowerCaseRule()));
            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDefaultFiles();
        }
    }
}
