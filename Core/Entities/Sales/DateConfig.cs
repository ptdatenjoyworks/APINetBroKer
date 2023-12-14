using Core.Entities.Contract;
using Core.Entities.Enum;
using Core.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Sales
{
    public class DateConfig
    {
        public DateConfig(int? commisionId, ControlDateType controlDateType, ControlDateModifierType controlDateModifierType, ControlDateOffsetType controlDateOffsetType, int controlDateOffsetValue)
        {
            CommisionId = commisionId;
            ControlDateType = controlDateType;
            ControlDateModifierType = controlDateModifierType;
            ControlDateOffsetType = controlDateOffsetType;
            ControlDateOffsetValue = controlDateOffsetValue;
        }

        [Column("Id")]
        public int Id { get; set; }

        //FK Commision
        public int? CommisionId { get; private set; }
        public Commision? Commision { get; private set; }


        public ControlDateType ControlDateType { get; private set; }
        public ControlDateModifierType ControlDateModifierType { get; private set; }
        public ControlDateOffsetType ControlDateOffsetType { get; private set; }
        public int ControlDateOffsetValue { get; private set; }

        public DateTime ControlDate(Contract.ContractItem contractItem)

        {
            switch (ControlDateType)
            {
                case ControlDateType.SoldDate:
                    return contractItem.Contracts?.SoldDate ?? DateTime.MinValue;
                case ControlDateType.ServiceStartDate:
                    return contractItem?.StartDate ?? DateTime.MinValue;
                case ControlDateType.CustomerInvoiceDate:
                    return contractItem?.StartDate.AddMonths(1) ?? DateTime.MinValue;
                case ControlDateType.CustomerPaymentDate:
                    return contractItem?.StartDate.AddMonths(2) ?? DateTime.MinValue;
                case ControlDateType.SupplierInvoiceDate:
                    return contractItem?.StartDate.GetNextDayOfWeek(DayOfWeek.Monday).GetNextDayOfWeek(DayOfWeek.Tuesday) ?? DateTime.MinValue;
                case ControlDateType.UtilityAcceptanceDate:
                    return contractItem?.StartDate.AddMonths(-1) ?? DateTime.MinValue;
                default: return DateTime.MinValue;
            }
        }

        public DateTime ControlDateModifier(DateTime date)
        {
            switch (ControlDateModifierType)
            {
                case ControlDateModifierType.NoModifier:
                    return date;
                case ControlDateModifierType.EndOfMonth:
                    return date.GetLastDateOfMonth(0);
                case ControlDateModifierType.EndOfQuarter:
                    return date.GetLastDayOfQuarter();
                case ControlDateModifierType.OneMonthAfter:
                    return date.AddMonths(1);
                case ControlDateModifierType.TwoMonthsAfter:
                    return date.AddMonths(2);
                case ControlDateModifierType.ThreeMonthsAfter:
                    return date.AddMonths(3);
                case ControlDateModifierType.Days2ndOr16thOfMonthAfter:
                    return date.GetDays2ndOr16thOfMonthAfter();
                case ControlDateModifierType.DaysAfter15thOfMonthAfter:
                    date = date.AddMonths(1);
                    return new DateTime(date.Year, date.Month, 15);
                case ControlDateModifierType.OneYearAfter:
                    return date.AddYears(1);
                case ControlDateModifierType.Minus3Months:
                    return date.AddMonths(-3);
                case ControlDateModifierType.Minus5Months:
                    return date.AddMonths(-5);
                case ControlDateModifierType.FirstFridayAfter:
                    return date.GetNextFriday();
                case ControlDateModifierType.DayUpToOrAfter23rd:
                    return date.Day <= 23 ? date.GetLastDateOfMonth(1) : date.GetLastDateOfMonth(2);
                case ControlDateModifierType.LastThursdayOfMonth:
                    return date.GetLastThurdayOfMonth();
                case ControlDateModifierType.Minus2Years:
                    return date.AddYears(-2);
                case ControlDateModifierType.CutOff15ofMonthFollowingWednesday:
                    return date.CutOff15ofMonthFollow(DayOfWeek.Wednesday);
                case ControlDateModifierType.CutOff15ofMonthFollowingThursday:
                    return date.CutOff15ofMonthFollow(DayOfWeek.Thursday);
                default:
                    return date;
            }
        }

        public DateTime ControlDateOffset(DateTime date)
        {
            if (ControlDateOffsetValue < 0)
            {
                return date;
            }
            switch (ControlDateOffsetType)
            {
                case ControlDateOffsetType.NoOffset:
                    return date;
                case ControlDateOffsetType.BusinessDays:
                    return date.AddBusinessDays(ControlDateOffsetValue);
                case ControlDateOffsetType.CalendarDays:
                    return date.AddDays(ControlDateOffsetValue);
                case ControlDateOffsetType.DayOfMonth:
                    var lastDateOfMonth = DateTime.DaysInMonth(date.Year, date.Month);
                    return ControlDateOffsetValue > lastDateOfMonth ? new DateTime(date.Year, date.Month, lastDateOfMonth) : new DateTime(date.Year, date.Month, ControlDateOffsetValue);
                case ControlDateOffsetType.DayOfWeek_Fridays:
                    return date.GetFridayAfterWeek(ControlDateOffsetValue);
                case ControlDateOffsetType.Months:
                    return date.AddMonths(ControlDateOffsetValue);
                case ControlDateOffsetType.Years:
                    return date.AddYears(ControlDateOffsetValue);
                case ControlDateOffsetType.FirstDayAfterOffSet_Fridays:
                    if(ControlDateOffsetValue > DateTime.DaysInMonth(date.Year, date.Month))
                    {
                        ControlDateOffsetValue = DateTime.DaysInMonth(date.Year, date.Month);
                    }
                    return new DateTime(date.Year, date.Month, ControlDateOffsetValue).GetNextFriday();
                default: return date;
            }
        }

        public DateTime GetDateConfig(ContractItem contractItem)
        {
            var dateControl = ControlDate(contractItem);
            var dateControlDateModifier = ControlDateModifier(dateControl);
            return ControlDateOffset(dateControlDateModifier);
        }
        

    }
}
