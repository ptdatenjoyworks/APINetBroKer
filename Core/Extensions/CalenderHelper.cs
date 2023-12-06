using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (date.Day < 16)
            {
                return new DateTime(date.AddMonths(1).Year, date.AddMonths(1).Month, 2);
            }
            else
            {
                return new DateTime(date.AddMonths(1).Year, date.AddMonths(1).Month, 16);
            }
        }
        public static DateTime GetNextFriday(this DateTime date)
        {
            var dateCount = ((int)DayOfWeek.Friday - (int)date.DayOfWeek + 7) % 7;
            return date.AddDays(dateCount);
        }
        public static DateTime GetLastThurdayOfMonth(this DateTime date)
        {
            var lastDateOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            var datediff = (lastDateOfMonth - date).Days + 1;
            var lastThursdaysBetweenDates = Enumerable.Range(0, datediff)
    .Select(x => date.AddDays(x))
    .Where(d => d.DayOfWeek == DayOfWeek.Thursday)
    .GroupBy(d => d.Month)
    .Select(grp => grp.Max(d => d));
            return lastThursdaysBetweenDates.FirstOrDefault(); ;
        }

        public static DateTime CutOff15ofMonthFollowingWednesday(this DateTime date, DayOfWeek dayOfWeek)
        {
            var datecutoff = new DateTime(date.Year, date.Month, 15);
            var is15ofMonthIsDayOfWeek = datecutoff.DayOfWeek == dayOfWeek;
            var datediff = (new DateTime(datecutoff.AddMonths(1).Year, datecutoff.AddMonths(1).Month, DateTime.DaysInMonth(datecutoff.AddMonths(1).Year, datecutoff.AddMonths(1).Month)) - datecutoff.AddMonths(1)).Days + 1;
            if (is15ofMonthIsDayOfWeek)
            {
                if (datecutoff.Day > date.Day)
                {
                    return datecutoff;
                }
                else
                {
                    var firstDateAfterDate15 = Enumerable.Range(0, datediff)
                                                .Select(x => datecutoff.AddMonths(1).AddDays(x))
                                                .Where(d => d.DayOfWeek == dayOfWeek)
                                                .GroupBy(d => d.Month)
                                                .Select(grp => grp.Min(d => d));
                    return firstDateAfterDate15.FirstOrDefault();
                }
            }
            else
            {
                var firstDateAfterDate15 = Enumerable.Range(0, datediff)
                                            .Select(x => datecutoff.AddMonths(1).AddDays(x))
                                            .Where(d => d.DayOfWeek == dayOfWeek)
                                            .GroupBy(d => d.Month)
                                            .Select(grp => grp.Min(d => d));
                return firstDateAfterDate15.FirstOrDefault();
            }
        }

        public static DateTime AddDaysCustom(this DateTime date, int dayAdd)
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
            int daysUntilFriday = ((int)DayOfWeek.Friday - (int)currentDayOfWeek + 7) % 7;

         /*   // Nếu là thứ 6, thì lấy ngày hôm sau (thứ 7)
            if (currentDayOfWeek == DayOfWeek.Friday)
            {
                daysUntilFriday = 1;
            }*/

            int totalDays = offsetValue * 7 + daysUntilFriday;
            return date.AddDays(totalDays);
        }
    }
}
