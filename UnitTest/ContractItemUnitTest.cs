using Core.Entities.Contract;
using Core.Entities.Enum;

namespace UnitTest
{
    public class ContractItemUnitTest
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
        public void Create_InvalidProductType()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var contract = new ContractItem(1, "", new DateTime(2023, 07, 01), 2, ProductType.Gas, EnergyUnitType.KWH, 1, 1, 1);
            }, $"ProductType : {ProductType.Gas}  khong phu hop voi Energy : {EnergyUnitType.KWH}");
        }
    }
}
