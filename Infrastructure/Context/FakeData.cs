using Bogus;
using Core.Entities.Contract;
using Core.Entities.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Context
{
    public static class FakeData
    {
        public static async Task InitData(this IServiceCollection services)
        {
            try
            {
                // Build the intermediate service provider
                var sp = services.BuildServiceProvider();

                // This will succeed.
                var dbContext = sp.GetService<DataContext>();
                var suppliers = dbContext.Suppliers.ToList();
                if (suppliers.Count() < 1000)
                {
                    var fakerSupplier = new Faker<Supplier>()
                   .RuleFor(x => x.Name, f => f.Company.CompanyName());

                    suppliers = fakerSupplier.Generate(1000);

                    await dbContext.Suppliers.AddRangeAsync(suppliers);
                    await dbContext.SaveChangesAsync();
                }


                var contracts = dbContext.Contracts.ToList();
                if (dbContext.Contracts.Count() < 300000)
                {
                    var fakerContract = new Faker<Contract>()
         .RuleFor(x => x.SupplierId, p => p.PickRandom(suppliers.Select(x => x.Id)));

                    contracts = fakerContract.Generate(300000);
                    await dbContext.Contracts.AddRangeAsync(contracts);
                    await dbContext.SaveChangesAsync();
                }

                var contractItems = dbContext.ContractItems.ToList();
                if (dbContext.ContractItems.Count() < 1000000)
                {
                    var fakerContractitem = new Faker<ContractItem>()
                  .RuleFor(x => x.Contracts, p => p.PickRandom(contracts))
                  .RuleFor(x => x.StartDate, p => p.Date.Between(new DateTime(2022, 01, 01), new DateTime(2023, 12, 31)))
                  .RuleFor(x => x.EndDate, p => p.Date.Between(new DateTime(2022, 01, 01), new DateTime(2023, 12, 31)))
                  .RuleFor(x => x.ContractMargin, p => p.PickRandom<decimal>(1000, 400000))
                  .RuleFor(x => x.AnnualUsage, p => p.PickRandom<int>(1000, 400000))
                  .RuleFor(x => x.Status, p => p.PickRandom<Status>());
                    contractItems = fakerContractitem.Generate(1000000);
                    await dbContext.ContractItems.AddRangeAsync(contractItems);
                    await dbContext.SaveChangesAsync();
                    int a = 0;
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }

        }
    }
}
