using System;

namespace  DateInterval.Exceptions
{
    public class IncorrectDateIntervalArgumentsException: Exception
    {
        public IncorrectDateIntervalArgumentsException()
        {
        }

        public IncorrectDateIntervalArgumentsException(string message)
            : base(message)
        {
        }

        public IncorrectDateIntervalArgumentsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}