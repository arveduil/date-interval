﻿using System;
using DateInterval.Exceptions;
using DateInterval.Extensions;
using DateInterval.Writers;

namespace DateInterval
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new DateIntervalProgram(new ConsoleWriter());
            program.Run(args);
        }
    }
}