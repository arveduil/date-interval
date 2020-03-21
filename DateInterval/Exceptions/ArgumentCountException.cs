using System;

namespace DateInterval.Exceptions
{
    public class ArgumentCountException : Exception
    {
        public ArgumentCountException()
        {
        }

        public ArgumentCountException(string message)
            : base(message)
        {
        }

        public ArgumentCountException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}