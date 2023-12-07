namespace Core.Extensions
{
    public static class CalenderHelper
    {
        public static DateTime GetNextDayOfWeek(this DateTime startDate, DayOfWeek dayOfWeek)
        {
            int daysUntilNextDay = ((int)dayOfWeek - (int)startDate.DayOfWeek + 7) % 7;
            return startDate.AddDays(daysUntilNextDay + 7);
        }

        public static DateTime GetLastDayOfQuarter(this DateTime date)
        {
            int quarter = (date.Month - 1) / 3 + 1;
            int lastMonthOfQuarter = quarter * 3;
            int daysInLastMonth = DateTime.DaysInMonth(date.Year, lastMonthOfQuarter);

            return new DateTime(date.Year, lastMonthOfQuarter, daysInLastMonth);
        }

        public static DateTime GetDays2ndOr16thOfMonthAfter(this DateTime date)
        {
            date = date.AddMonths(1);
            return date.Day < 16 ? new DateTime(date.Year, date.Month, 2) : new DateTime(date.Year, date.Month, 16);
        }
        public static DateTime GetNextFriday(this DateTime date)
        {
            if(date.DayOfWeek == DayOfWeek.Friday)
            {
                date = date.AddDays(1);
            }
            var dateCount = ((int)DayOfWeek.Friday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(dateCount);
        }
        public static DateTime GetLastThurdayOfMonth(this DateTime date)
        {
            var lastDateOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            if(lastDateOfMonth.DayOfWeek == DayOfWeek.Thursday)
            {
                return lastDateOfMonth;
            }
            var dateCount = ((int)DayOfWeek.Thursday - (int)lastDateOfMonth.DayOfWeek + 7) % 7;

            return lastDateOfMonth.AddDays(dateCount - 7);

        }

        public static DateTime CutOff15ofMonthFollow(this DateTime date, DayOfWeek dayOfWeek)
        {
            var datecutoff = new DateTime(date.Year, date.Month, 15);
            var is15ofMonthIsDayOfWeek = datecutoff.DayOfWeek == dayOfWeek;
            if (is15ofMonthIsDayOfWeek)
            {
                if (datecutoff.Day > date.Day)
                {
                    return datecutoff;
                }
                else
                {
                    var dateNextMonth = datecutoff.AddMonths(1);
                    int daysUntil = ((int)dayOfWeek - (int)dateNextMonth.DayOfWeek + 7) % 7;
                    return dateNextMonth.AddDays(daysUntil);
                }
            }
            else
            {
                var dateNextMonth = datecutoff.AddMonths(1);
                int daysUntil = ((int)dayOfWeek - (int)dateNextMonth.DayOfWeek + 7) % 7;
                return dateNextMonth.AddDays(daysUntil);
            }
        }

        public static DateTime AddBusinessDays(this DateTime date, int dayAdd)
        {  
            while (dayAdd > 0)
            {
                date = date.AddDays(1);
                dayAdd--;
                if(date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    dayAdd++;
                }
            }
            return date;
        }
        public static DateTime GetFridayAfterWeek(this DateTime date , int offsetValue)
        {
            DayOfWeek currentDayOfWeek = date.DayOfWeek;
            int daysUntilFriday = 0;
            if ((int)currentDayOfWeek >= (int)DayOfWeek.Friday)
            {
                daysUntilFriday = (int)DayOfWeek.Friday - (int)currentDayOfWeek;
            }
            else
            {
                daysUntilFriday = ((int)DayOfWeek.Friday - (int)currentDayOfWeek + 7) % 7;
            }
            int totalDays = offsetValue * 7 + daysUntilFriday;
            return date.AddDays(totalDays);
        }

        public static DateTime GetLastDateOfMonth(this DateTime date,int monthAdd) 
        {
            date = date.AddMonths(monthAdd);
            date = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            return date;
        }
    }
}
