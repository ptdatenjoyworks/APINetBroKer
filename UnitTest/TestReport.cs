using Bogus;
using Core.Entities.Contract;
using Core.Entities.Enum;

namespace UnitTest
{
    public  class TestReport
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create()
        {
            var contract = new ContractItem(1, "", new DateTime(2023, 07, 01), 2, ProductType.Gas, EnergyUnitType.MCF, 1, 1, 1);
            Assert.AreEqual(new DateTime(2023, 09, 01), contract.EndDate);
        }
        [Test]
        public void FakeData()
        {
            var listName = new string[] { "A", "B", "C", "D", "E", "F" };
            var fakerSupplier = new Faker<Supplier>()
                .RuleFor(x => x.Name, f => f.PickRandom(listName));
            var listSuppler = fakerSupplier.Generate(1000);
            var a = 1;
            /* var fakerContract = new Faker<Contract>()
                 .RuleFor()*/
        }
    }
}
