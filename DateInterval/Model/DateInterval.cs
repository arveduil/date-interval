using System;
using DateInterval.Exceptions;
using DateInterval.Extensions;

namespace DateInterval.Model
{
    public class DateInterval
    {
        private const string Delimiter = "-";
        
        private readonly DateTime _start;

        private readonly DateTime _end;

        private readonly DateDisplayFormat _dateDisplayFormat;

        public DateInterval(DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
            ValidateStartIsBeforeEnd();
            _dateDisplayFormat = GetDateDisplayFormat();
        }

        private void ValidateStartIsBeforeEnd()
        {
            if (_start > _end)
            {
                throw new IncorrectDateIntervalArgumentsException("Start date is earlier than end date.");
            }
        }

        public override string ToString()
        {
            return $"{_start.ToString(_dateDisplayFormat)} {Delimiter} {_end.ToString(DateDisplayFormat.DayMonthYear)}";
        }

        private DateDisplayFormat GetDateDisplayFormat()
        {
            if (_start.IsTheSameMonth(_end))
            {
                return DateDisplayFormat.Day;
            }

            return _start.IsTheSameYear(_end) ? DateDisplayFormat.DayMonth : DateDisplayFormat.DayMonthYear;
        }
    }
}