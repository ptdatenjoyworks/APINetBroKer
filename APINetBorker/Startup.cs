using APINetBorker.Controllers;
using APINetBorker.Extensions;
using APINetBorker.Migrations;
using Core.Models.Profiles;
using Core.Services;
using Domain.Service;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace APINetBorker
{
    public class Startup
    {
        private IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
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
