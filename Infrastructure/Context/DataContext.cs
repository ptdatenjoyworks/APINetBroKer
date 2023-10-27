using Core.Entities;
using Core.Entities.Contract;
using Core.Entities.Sales;
using Core.Entities.User;
using Infrastructure.Context.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.Contracts;

namespace Infrastructure.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"), b => b.MigrationsAssembly("APINetBorker"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Core.Entities.Contract.Contract> Contracts { get; set; }
        public DbSet<ContractItem> ContractItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SalesProgram> SalePrograms { get; set; }
        public DbSet<DateConfig> DateConfigs { get; set; }
    }
}
