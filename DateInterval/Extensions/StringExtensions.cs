using System;
using System.Globalization;
using DateInterval.Exceptions;

namespace  DateInterval.Extensions
{
    public static class StringExtensions
    {
        public static DateTime Parse(this string dateTimeRaw)
        {
            try
            {
                return DateTime.ParseExact(dateTimeRaw,DateTimeFormats.DayMonthYearFormat, CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                throw new ArgumentParseException($"Cannot parse: {dateTimeRaw}, format accepted: {DateTimeFormats.DayMonthYearFormat} .",e);
            }
        }
    }
}