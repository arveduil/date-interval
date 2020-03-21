﻿using System;

namespace  DateInterval.Exceptions
{
    public class ArgumentParseException : Exception
    {
        public ArgumentParseException()
        {
        }

        public ArgumentParseException(string message)
            : base(message)
        {
        }

        public ArgumentParseException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}