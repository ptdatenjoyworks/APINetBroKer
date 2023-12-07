using Core.Entities.Contract;
using Core.Entities.Enum;
using Core.Entities.Sales;

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
        [Test]
        [TestCase(ControlDateModifierType.NoModifier, "2023-12-05", "2023-12-05")]
        [TestCase(ControlDateModifierType.EndOfMonth, "2023-12-05", "2023-12-31")]
        [TestCase(ControlDateModifierType.EndOfQuarter, "2023-12-05", "2023-12-31")]
        [TestCase(ControlDateModifierType.OneMonthAfter, "2023-12-05", "2024-01-05")]
        [TestCase(ControlDateModifierType.TwoMonthsAfter, "2023-12-05", "2024-02-05")]
        [TestCase(ControlDateModifierType.ThreeMonthsAfter, "2023-12-05", "2024-03-05")]
        [TestCase(ControlDateModifierType.Days2ndOr16thOfMonthAfter, "2023-12-05", "2024-01-02")]
        [TestCase(ControlDateModifierType.DaysAfter15thOfMonthAfter, "2023-12-05", "2024-01-15")]
        [TestCase(ControlDateModifierType.OneYearAfter, "2023-12-05", "2024-12-05")]
        [TestCase(ControlDateModifierType.Minus3Months, "2023-12-05", "2023-09-05")]
        [TestCase(ControlDateModifierType.Minus5Months, "2023-12-05", "2023-07-05")]
        [TestCase(ControlDateModifierType.FirstFridayAfter, "2023-12-05", "2023-12-08")]
        [TestCase(ControlDateModifierType.DayUpToOrAfter23rd, "2023-12-05", "2024-01-31")]
        [TestCase(ControlDateModifierType.Minus2Years, "2023-12-05", "2021-12-05")]
        [TestCase(ControlDateModifierType.CutOff15ofMonthFollowingWednesday, "2023-12-05", "2024-01-17")]
        [TestCase(ControlDateModifierType.CutOff15ofMonthFollowingThursday, "2023-12-05", "2024-01-18")]
        [TestCase(ControlDateModifierType.LastThursdayOfMonth, "2023-12-01", "2023-12-28")]

        public void ControlDateModifierTest(ControlDateModifierType type, string inputDate, string result)
        {
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, type, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            var date = dateConfig.ControlDateModifier(DateTime.Parse(inputDate));

            Assert.AreEqual(DateTime.Parse(result), date);
        }

        [Test]
        [TestCase(ControlDateType.SoldDate, "2023-12-05", "2023-12-05", "2023-12-05")]
        [TestCase(ControlDateType.ServiceStartDate, "2023-12-05", "2023-12-05", "2023-12-05")]
        [TestCase(ControlDateType.CustomerInvoiceDate, "2023-12-05", "2023-12-05", "2024-1-05")]
        [TestCase(ControlDateType.CustomerPaymentDate, "2023-12-05", "2023-12-05", "2024-2-05")]
        [TestCase(ControlDateType.SupplierInvoiceDate, "2023-12-04", "2023-12-05", "2023-12-12")]
        [TestCase(ControlDateType.UtilityAcceptanceDate, "2023-12-04", "2023-12-05", "2023-11-04")]
        public void ControlDateTest(ControlDateType type, string startdate,string soldDate, string result)
        {
            var dateConfig = new DateConfig(1, type, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, DateTime.Parse(soldDate), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var cotractItem = new ContractItem(contract, "9138014006", DateTime.Parse(startdate), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var date = dateConfig.ControlDate(cotractItem);

            Assert.AreEqual(DateTime.Parse(result), date);
        }
        [Test]
        [TestCase(ControlDateOffsetType.DayOfWeek_Fridays, "2023-12-04", "2023-12-22")]
        [TestCase(ControlDateOffsetType.FirstDayAfterOffSet_Fridays, "2023-12-11", "2023-12-08")]
        [TestCase(ControlDateOffsetType.DayOfWeek_Fridays, "2023-12-09", "2023-12-22")]
        [TestCase(ControlDateOffsetType.DayOfWeek_Fridays, "2023-12-11", "2023-12-31")]
        public void ControlDateOffsetTest(ControlDateOffsetType type,string startdate, string result)
        {
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, type, 2);

            var date = dateConfig.ControlDateOffset(DateTime.Parse(startdate));

            Assert.AreEqual(DateTime.Parse(result), date);
        }
    }
}
