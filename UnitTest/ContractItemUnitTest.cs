using Core.Entities.Contract;
using Core.Entities.Enum;
using Core.Entities.Sales;
using Core.Services.Contracts;
using NUnit.Framework.Internal;
using System.Reflection.Metadata.Ecma335;

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
       /* [Test]
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
        [TestCase(ControlDateModifierType.CutOff15ofMonthFollowingWednesday, "2023-12-05", "2023-12-20")]
        [TestCase(ControlDateModifierType.CutOff15ofMonthFollowingThursday, "2023-12-05", "2023-12-21")]
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
        public void ControlDateTest(ControlDateType type, string startdate, string soldDate, string result)
        {
            var dateConfig = new DateConfig(1, type, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, DateTime.Parse(soldDate), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var cotractItem = new ContractItem(contract, "9138014006", DateTime.Parse(startdate), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var date = dateConfig.ControlDate(cotractItem);

            Assert.AreEqual(DateTime.Parse(result), date);
        }
        [Test]
        [TestCase(ControlDateOffsetType.DayOfWeek_Fridays, "2023-12-04", 2, "2023-12-22")]
        [TestCase(ControlDateOffsetType.FirstDayAfterOffSet_Fridays, "2023-12-11", 2, "2023-12-08")]
        [TestCase(ControlDateOffsetType.DayOfWeek_Fridays, "2023-12-09", 2, "2023-12-22")]
        [TestCase(ControlDateOffsetType.FirstDayAfterOffSet_Fridays, "2023-12-11", 32, "2024-01-05")]
        public void ControlDateOffsetTest(ControlDateOffsetType type, string startdate, int offset, string result)
        {
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, type, offset);

            var date = dateConfig.ControlDateOffset(DateTime.Parse(startdate));

            Assert.AreEqual(DateTime.Parse(result), date);
        }
*/

/*
        [Test]
        public void ForecastContractItemContractUpfront()
        {
            var commision = new ContractUpfront(1, "ContractUpfront", ProgramAdderType.Override, 0.007m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);

            var forecasts = commision.GetListContractItemForecast(contractItem);
            Assert.AreEqual(1, forecasts.Count);
            var firstForecast = forecasts.FirstOrDefault();
            Assert.AreEqual(437.99m, firstForecast.Amount);
            Assert.AreEqual(new DateTime(2023, 03, 31), firstForecast.ForecastDate);
        }

        [Test]
        public void ForecastContractItemQuarterlyUpfront()
        {
            var commision = new QuarterlyUpfront(1, "QuarterlyUpfront", ProgramAdderType.Override, 0.007m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);

            var forecasts = commision.GetListContractItemForecast(contractItem);
            Assert.AreEqual(8, forecasts.Count);
            var firstForecast = forecasts.FirstOrDefault();
            Assert.AreEqual(109.50m, firstForecast.Amount);
            Assert.AreEqual(new DateTime(2023, 03, 31), firstForecast.ForecastDate);
            for (int i = 0; i < forecasts.Count - 1; i++)
            {
                Assert.IsTrue((forecasts[i + 1].ForecastDate == forecasts[i].ForecastDate.Date.AddMonths(3)));

            }
            Assert.AreEqual(109.47, forecasts.LastOrDefault().Amount);

        }
        [Test]
        public void ForecastContractItemPercentageContractResidual()
        {
            var commision = new PercentageContractResidual(1, "PercentageContractResidual", ProgramAdderType.Override, 0.007m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var listContractItemforecast = new List<ContractItemForecast>()
            {
                new ContractItemForecast(1,109.50m,new DateTime(2023, 03, 25)),
                new ContractItemForecast(1,109.50m,new DateTime(2023, 04, 25)),
                new ContractItemForecast(1,109.50m,new DateTime(2023, 05, 25)),
                new ContractItemForecast(1,109.50m,new DateTime(2023, 06, 25))
            };
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(listContractItemforecast, contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);

            var forecasts = commision.GetListContractItemForecast(contractItem);


            Assert.AreEqual(20, forecasts.Count);
            var firstForecast = forecasts.FirstOrDefault();
            Assert.AreEqual(36, firstForecast.Amount);
            Assert.AreEqual(new DateTime(2023, 07, 25), firstForecast.ForecastDate);
            for (int i = 0; i < forecasts.Count - 1; i++)
            {
                Assert.IsTrue((forecasts[i + 1].ForecastDate == forecasts[i].ForecastDate.Date.AddMonths(1)));

            }
            Assert.AreEqual(-246.02, forecasts.LastOrDefault().Amount);

        }
        [Test]
        public void ForecastContractItemTotal()
        {
            var commision1 = new ContractUpfront(1, "ContractUpfront", ProgramAdderType.Override, 0.007m, 0.5m);
            var commision2 = new QuarterlyUpfront(1, "QuarterlyUpfront", ProgramAdderType.Override, 0.007m, 0.5m);
            var commision = new PercentageContractResidual(1, "PercentageContractResidual", ProgramAdderType.Override, 0.007m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            commision1.SetDateConfig(dateConfig);
            commision2.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var listCommision = new List<Commision>();
            listCommision.Add(commision1);
            listCommision.Add(commision);
            listCommision.Add(commision2);

            var saleprogram = new SalesProgram(listCommision, EnergyUnitType.CCF, "", "");
            var listContractItemforecast = new List<ContractItemForecast>()
            {
                new ContractItemForecast(1,109.50m,new DateTime(2023, 03, 25)),
                new ContractItemForecast(1,109.50m,new DateTime(2023, 04, 25)),
                new ContractItemForecast(1,109.50m,new DateTime(2023, 05, 25)),
                new ContractItemForecast(1,109.50m,new DateTime(2023, 06, 25))
            };
            var contractItem = new ContractItem(saleprogram, listContractItemforecast, contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var listforecast = new List<ContractItemForecast>();
            foreach (var item in contractItem.SalesProgram.Commisions)
            {
                var forecast = item.GetListContractItemForecast(contractItem);
                forecast.ForEach(p => contractItem.ContractItemForecasts.Add(p));
            }

            Assert.AreEqual(32, contractItem.ContractItemForecasts.Count);
        }*/

        [Test]
        public void ForecastContractItemAnnualUpfront()
        {
            var commision = new AnnualUpfront(1, "AnnualUpfront", ProgramAdderType.Override, 0.007m, 0.5m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var forecasts = commision.GetListContractItemForecast(contractItem);

            Assert.AreEqual(4, forecasts.Count);
            var firstForecast = forecasts.FirstOrDefault();
            Assert.AreEqual(408.79m, firstForecast.Amount);
            for (int i = 0; i < forecasts.Where(p=>p.Amount>0).Count() - 1; i++)
            {
                Assert.IsTrue((forecasts[i + 2].ForecastDate == forecasts[i].ForecastDate.Date.AddYears(1)));

            }
            Assert.AreEqual(408.78m, forecasts.Where(p => p.Amount > 0).LastOrDefault().Amount);

            for (int i = 0; i < forecasts.Where(p => p.Amount < 0).Count() - 1; i++)
            {
                Assert.IsTrue((forecasts[i + 2].ForecastDate == forecasts[i].ForecastDate.Date.AddYears(1)));
            }
            Assert.AreEqual(-204.40m, forecasts.Where(p => p.Amount < 0).FirstOrDefault().Amount);
        }
        [Test]
        public void ForecastContractItemBridge()
        {
            var commision = new Bridge(500,1,"");
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var forecasts = commision.GetListContractItemForecast(contractItem);

            Assert.AreEqual(1, forecasts.Count);
            Assert.AreEqual(500, forecasts.FirstOrDefault().Amount);
        }
        [Test]
        public void ForecastContractItemFirstAnnualUpfront()
        {
            var commision = new FirstAnnualUpfront(1, "FirstAnnualUpfront", ProgramAdderType.Override, 0.007m, 0.5m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var forecasts = commision.GetListContractItemForecast(contractItem);

            Assert.AreEqual(2, forecasts.Count);
            var firstForecast = forecasts.FirstOrDefault();
            Assert.AreEqual(408.79m, firstForecast.Amount);
            Assert.AreEqual(-204.40m, forecasts.Where(p => p.Amount < 0).FirstOrDefault().Amount);
        } 
        [Test]
        public void ForecastContractItemFirstAnnualUpfront25kMax()
        {
            var commision = new FirstAnnualUpfront25kMax(1, "FirstAnnualUpfront", ProgramAdderType.Override, 0.007m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var forecasts = commision.GetListContractItemForecast(contractItem);

            Assert.AreEqual(1, forecasts.Count);
            var firstForecast = forecasts.FirstOrDefault();
            Assert.AreEqual(408.79m, firstForecast.Amount);
        } 
        [Test]
        public void ForecastContractItemPercentageAdderResidual()
        {
            var commision = new PercentageAdderResidual(1, "PercentageAdderResidual", ProgramAdderType.Override, 0.007m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var forecasts = commision.GetListContractItemForecast(contractItem);

            Assert.AreEqual(24, forecasts.Count);
            Assert.AreEqual(408.79m, forecasts.Sum(x => x.Amount));
        } 
        [Test]
        public void ForecastContractItemPercentageFirstAnnualRemainderResidual()
        {
            var commision = new PercentageFirstAnnualRemainderResidual(1, "PercentageFirstAnnualRemainderResidual", ProgramAdderType.Override, 0.007m, 0.5m);
            var dateConfig = new DateConfig(1, ControlDateType.SoldDate, ControlDateModifierType.NoModifier, ControlDateOffsetType.DayOfWeek_Fridays, 2);
            commision.SetDateConfig(dateConfig);
            var contract = new Contract("John A", 1, 1, 1, 1, 1, new DateTime(2023, 03, 14), Core.Entities.Enum.BillingChargeType.AllIn, Core.Entities.Enum.BillingType.ChickenRanch, Core.Entities.Enum.EnrollmentType.TPV, Core.Entities.Enum.PricingType.Matrix, Core.Entities.Enum.Stage.Opportunity);
            var contractItem = new ContractItem(contract, "9138014006", new DateTime(2023, 03, 14), 24, ProductType.Elec, EnergyUnitType.KWH, 58398, 0.01275m, 0.0075m);
            var forecasts = commision.GetListContractItemForecast(contractItem);

            Assert.AreEqual(12, forecasts.Count);
            Assert.AreEqual(204.36m, forecasts.Sum(x => x.Amount));
        }

    }
}
