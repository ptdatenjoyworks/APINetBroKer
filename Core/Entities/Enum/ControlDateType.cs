namespace Core.Entities.Enum
{
    public enum ControlDateType
    {
        None,
        SoldDate,
        ServiceStartDate,
        CustomerInvoiceDate,
        CustomerPaymentDate,
        SupplierInvoiceDate,
        UtilityAcceptanceDate
    }
    public enum ControlDateModifierType
    {
        NoModifier,
        EndOfMonth,
        EndOfQuarter,
        OneMonthAfter,
        TwoMonthsAfter,
        ThreeMonthsAfter,
        Days2ndOr16thOfMonthAfter,
        DaysAfter15thOfMonthAfter,
        OneYearAfter,
        Minus3Months,
        Minus5Months,
        FirstFridayAfter,
        DayUpToOrAfter23rd,
        LastThursdayOfMonth,
        Minus2Years,
        CutOff15ofMonthFollowingWednesday,
        CutOff15ofMonthFollowingThursday
    }
    public enum ControlDateOffsetType
    {
        NoOffset,
        DayOfWeek_Fridays,
        BusinessDays,
        CalendarDays,
        DayOfMonth,
        Months,
        Years,
        FirstDayAfterOffSet_Fridays
    }
}
