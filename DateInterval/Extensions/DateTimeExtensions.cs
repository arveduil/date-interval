using System;
using DateInterval.Model;

namespace DateInterval.Extensions
{
    public static class DateTimeExtensions
    {
        
        public static bool IsTheSameYear(this DateTime firstDateTime, DateTime secondDateTime)
        {
            return firstDateTime.Year == secondDateTime.Year;
        }
        
        public static bool IsTheSameMonth(this DateTime firstDateTime, DateTime secondDateTime)
        {
            return firstDateTime.Month == secondDateTime.Month && IsTheSameYear(firstDateTime,secondDateTime);
        }

        private static string GetDayString(this DateTime dateTime)
        {
            return dateTime.ToString(DateTimeFormats.DayFormat);
        }
        
        private static string GetDayMonthString(this DateTime dateTime)
        {
            return dateTime.ToString(DateTimeFormats.DayMonthFormat);
        }
        
        private static string GetDayMonthYearString(this DateTime dateTime)
        {
            return dateTime.ToString(DateTimeFormats.DayMonthYearFormat);
        }
        
        public static string ToString(this DateTime dateTime, DateDisplayFormat format)
        {
            return format switch
            {
                DateDisplayFormat.Day => dateTime.GetDayString(),
                DateDisplayFormat.DayMonth => dateTime.GetDayMonthString(),
                DateDisplayFormat.DayMonthYear => dateTime.GetDayMonthYearString(),
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, "Inappropriate format.")
            };
        }
    }
}